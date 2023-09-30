using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.SubjectModels;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectCommands
{
    public class DeleteLecturerInSubject : CommandBase
    {
        private readonly DeleteLecturersOnSubjectCommandModel _model;
        public DeleteLecturerInSubject(RepositoryProvider repositoryProvider,
            DeleteLecturersOnSubjectCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var Delete = await _repositoryProvider.LecturersSubject.GetQueryable()
                .FirstOrDefaultAsync(x => x.SubjectId == _model.SubjectId && x.LecturerId == _model.LecturerId);

            if (Delete == null)
            {
                return Result.Error(" ვერ მოიძებანა");
            }

            _repositoryProvider.LecturersSubject.Delete(Delete);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("წარმატებით წაიშალა");

        }


    }
}
