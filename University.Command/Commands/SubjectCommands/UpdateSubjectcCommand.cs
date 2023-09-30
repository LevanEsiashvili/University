using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectModels;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectCommands
{
    public class UpdateSubjectcCommand : CommandBase
    {
        private readonly UpdateSubjectCommandModel _model;
        public UpdateSubjectcCommand(RepositoryProvider repositoryProvider,UpdateSubjectCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var subject = await _repositoryProvider.Subjects.GetQueryable().FirstOrDefaultAsync(x=>x.Id == _model.Id);

            if (subject == null)
            {
                return Result.Error("საგანი არ მოიძებნა");
            }
            subject.Id = _model.Id;
            subject.Name = _model.Name;
            subject.Description = _model.Description;
            if (_model.FacultyId != null )
            {
                if (!_repositoryProvider.Faculties.GetQueryable().Any(x => x.Id == _model.FacultyId))
                {
                    return Result.Error("მსგავსი ფაკულტეტი არ არსებობს");
                }
                subject.FacultyId = _model.FacultyId.Value;
            }

            _repositoryProvider.Subjects.Update(subject);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("საგანი წარმატებით განახლდა");

           
        }
    }
}
