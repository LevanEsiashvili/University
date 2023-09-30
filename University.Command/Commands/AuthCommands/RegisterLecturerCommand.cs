using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.AuthModels;
using University.Domain.Contracts;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Users;
using University.Domain.Service;
using University.Infrastructure;
using University.Shared.Enumes;
using University.Shared.Models;

namespace University.Command.Commands.AuthCommands
{
    public class RegisterLecturerCommand : CommandBase
    {
        private readonly RegisterLecturerCommandModel _model;
        public RegisterLecturerCommand(RepositoryProvider repositoryProvider,
            IAuthorizedUserService authorizedUserService,
            RegisterLecturerCommandModel model) : base(repositoryProvider, authorizedUserService)
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

            if (similarUser != null)
            {
                return Result.Error("მსგავსი მეილით მომხმარებელი უკვე არსებობს");
            }

            


            byte[] passwordHash;
            byte[] passwordSalt;

            AuthService authService = new AuthService();
            authService.CreatePasswordHash(_model.Password, out passwordHash, out passwordSalt);

            var lecturer = new User()
            {
                Role = Role.Lecturer,
                Email = _model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                BirtsDate = _model.BirtsDate,
                PrivateNumber = _model.PrivateNumber,
                PhoneNumber = _model.PhoneNumber,

                Lecturer = new Lecturer()
                {
                    Profession = _model.Profession,
                    QualificationYare = _model.QualificationYare,
                }
            };

            var token = _authorizedUserService.GenerateToken(lecturer);

            _repositoryProvider.Users.Create(lecturer);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success((object)token);
        }
    }
}
