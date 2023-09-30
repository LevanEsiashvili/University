using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectModels;
using University.Command.CommandModels.SubjectProgramModels;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectProgramCommand
{
    public class UpdateSubjectProgramCommand : CommandBase
    {
        private readonly UpdateSubjectProgramModel _model;
        public UpdateSubjectProgramCommand(RepositoryProvider repositoryProvider,UpdateSubjectProgramModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var update =  await _repositoryProvider.SubjectProgrames.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _model.Id);

            if (update == null) { return Result.Success("ასეთი სილაბუსი არ არსებობს"); }

            update.Description = _model.Description;
            update.BookName = _model.BookName;
            update.BookPages = _model.BookPages;
            update.StartTime = _model.StartTime;
            update.StartTime = _model.StartTime;
            update.EndTime = _model.EndTime;

            _repositoryProvider.SubjectProgrames.Update(update);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success("წარმატებით განახლდა");
            

        }
    }
}
