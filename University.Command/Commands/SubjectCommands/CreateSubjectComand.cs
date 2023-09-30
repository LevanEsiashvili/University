using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.SubjectModels;
using University.Domain.Entities.Subjects;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectCommands
{
    public class CreateSubjectComand : CommandBase
    {
        private readonly CreateSubjectCommandModel _model;
        public CreateSubjectComand(RepositoryProvider repositoryProvider, CreateSubjectCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var oldSubject = await _repositoryProvider.Subjects.GetQueryable().FirstOrDefaultAsync(x => x.Name == _model.Name);

            if (oldSubject != null)
            {
                return Result.Error("ასეთი საგანი  არსებობს");
            }

            if (!_repositoryProvider.Faculties.GetQueryable().Any(x => x.Id == _model.FacultyId))
            { return Result.Error("ასეთი ფაკულტეტი არ  არსებობს"); }



            var subject = new Subject()
            {
                Name = _model.Name,
                Description = _model.Description,
                FacultyId = _model.FacultyId,
               
                
            };

            _repositoryProvider.Subjects.Create(subject);   
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("წარმატებით შეიქმნა");


        }
    }
}
