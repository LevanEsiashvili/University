using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.AuthModels;
using University.Domain.Contracts;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Users;
using University.Domain.Service;
using University.Infrastructure;
using University.Shared.Enumes;
using University.Shared.Models;
using University.Domain.Entities.Students;

namespace University.Command.Commands.AuthCommands
{
    public class RegisterStudentCommand : CommandBase
    {
        private readonly RegisterStudentCommandModel _model;
        public RegisterStudentCommand(RepositoryProvider repositoryProvider,
            IAuthorizedUserService authorizedUserService,
            RegisterStudentCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            if (_model.Password != _model.ConfirmPassword)
            {
                return Result.Error("პაროლები არ ემთხვევა ერთმანეთს");
            }

            var similarUser = await _repositoryProvider.Users.GetQueryable()
                .FirstOrDefaultAsync(x => x.Email == _model.Email);

            if ( !await _repositoryProvider.Faculties.GetQueryable().AnyAsync(x=> x.Id == _model.FacultyId))
            {
                return Result.Error("ფაკულტეტი ვერ მოიძებნა");
            }

            if (similarUser != null)
            {
                return Result.Error("მსგავსი მეილით მომხმარებელი უკვე არსებობს");
            }

            


            byte[] passwordHash;
            byte[] passwordSalt;

            AuthService authService = new AuthService();
            authService.CreatePasswordHash(_model.Password, out passwordHash, out passwordSalt);

            var student = new User()
            {
                Role = Role.Student,
                Email = _model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                BirtsDate = _model.BirtsDate,
                PrivateNumber = _model.PrivateNumber,
                PhoneNumber = _model.PhoneNumber,

                Student = new Student()
                {
                    GPA = _model.GPA,
                    GraduatedSchool = _model.GraduatedSchool,
                    FacultyId = _model.FacultyId,
                }

                
            };

            var token = _authorizedUserService.GenerateToken(student);

            _repositoryProvider.Users.Create(student);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success((object)token);
        }
    }
}
