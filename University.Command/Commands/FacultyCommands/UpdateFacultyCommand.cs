using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.FacultyModels;
using University.Domain.Entities.Faculties;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.FacultyCommands
{
    public class UpdateFacultyCommand : CommandBase
    {
        private readonly UpdateFacultyCommandModel _model;
          
        public UpdateFacultyCommand(RepositoryProvider repositoryProvider,UpdateFacultyCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var faculty = await _repositoryProvider.Faculties.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _model.Id);
            if (faculty == null)
            {
                return Result.Error("ფაკულტეტი ვერ მოიძებნა");
            }

            faculty.Id = _model.Id;
            faculty.Name = _model.Name;
            faculty.Description = _model.Description;
            
           

            _repositoryProvider.Faculties.Update(faculty);
            _repositoryProvider.UnitOfWork.SaveChange();
            

            return  Result.Success(faculty);
        }
    }
}
