using University.Command.CommandModels.ChooseSubjectModels;
using University.Domain.Contracts;
using University.Domain.Entities.StudentSubjects;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.ChooseSubjectCommands
{
    public class ChooseSubjectCommand : CommandBase
    {
        public readonly ChooseSubjectModel _model;

        public ChooseSubjectCommand(RepositoryProvider repositoryProvider,
            IAuthorizedUserService authorizedUserService,
            ChooseSubjectModel model) : base(repositoryProvider, authorizedUserService)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var curentStudentId = _authorizedUserService.GetCurrentStudentId();

            var studentSubject = new StudentSubject()
            {
                StudentId = curentStudentId,
                SubjectId = _model.SubjectId,
                Type = StudentSubjectType.Current,
                RegistrationDate = DateTime.Now
            };

            _repositoryProvider.StudentSubjects.Create(studentSubject);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("საგნი არჩეულია");
        }
    }
}
