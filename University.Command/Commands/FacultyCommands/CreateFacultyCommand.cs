using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.FacultyModels;
using University.Domain.Entities.Faculties;
using University.Infrastructure;
using University.Infrastructure.Database.Mapping;
using University.Shared.Models;

namespace University.Command.Commands.FacultyCommands
{
    public class CreateFacultyCommand : CommandBase

    {
        private readonly CreateFacultyCommandModel _model;
        public CreateFacultyCommand(RepositoryProvider repositoryProvider, CreateFacultyCommandModel model) : base(repositoryProvider)
        {
            _model = model;

        }

        public override async Task<Result> HandleAsync()
        {
            var old = await _repositoryProvider.Faculties.GetQueryable()
                .FirstOrDefaultAsync(x => x.Name == _model.Name && !x.IsDeleted);
            if (old != null)
            {
                return Result.Error("ფაკულტეტი უკვე არსებობს");
            }

            var faculty = new Faculty()
            {
                Name = _model.Name,
                Description = _model.Description,

            };

            _repositoryProvider.Faculties.Create(faculty);
            _repositoryProvider.UnitOfWork.SaveChange();
            return Result.Success("ფაკულტეტი წარმატებით შეიქმნა");


        }
    }
}
