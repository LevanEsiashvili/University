using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.ExamModels;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.ExamCommands
{
    public class DeleteExamCommand : CommandBase
    {
        private readonly DeleteExamModel _model;
        public DeleteExamCommand(RepositoryProvider repositoryProvider, DeleteExamModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var DeleteExam = await _repositoryProvider.Exams.GetQueryable().FirstOrDefaultAsync(x=> x.Id ==_model.Id);

            if (DeleteExam == null)
            {
                return Result.Error("გამოცდა ვერ მოიძებნა");
            }

            DeleteExam.Delete();

            _repositoryProvider.Exams.Update(DeleteExam);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("წარმატებით წაიშალა");
        }
    }
}
