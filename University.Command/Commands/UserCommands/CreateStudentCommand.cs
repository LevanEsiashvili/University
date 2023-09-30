using University.Command.CommandModels.UserModels;
using University.Domain.Entities.Users;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.UserCommands
{
    public class CreateStudentCommand : CommandBase
    {
        public readonly CreateStudentCommandModel _model;

        public CreateStudentCommand(RepositoryProvider repositoryProvider, CreateStudentCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var user = new User()
            {
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                Email = _model.Email,
                BirtsDate = _model.BirtsDate,
                PrivateNumber = _model.PrivateNumber,
                PhoneNumber = _model.PhoneNumber,
                PasswordHash = default,
                PasswordSalt = default,
                Student = new Domain.Entities.Students.Student()
                {
                    GPA = _model.GPA,
                    GraduatedSchool = _model.GraduatedSchool,
                    FacultyId = _model.FacultyId
                }
            };

            _repositoryProvider.Users.Create(user);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success("სტუდენტი წარმატებით შიქმნა");
        }
    }
}
