using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectModels;
using University.Command.CommandModels.SubjectProgramModels;
using University.Command.CommandModels.UserModels;
using University.Domain.Contracts;
using University.Domain.Entities.SubjectPrograms;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectProgramCommand
{
    public class CreateSubjectProgramCommand : CommandBase
    {
        private readonly CreateSubjectProgramModel _model;
        public CreateSubjectProgramCommand(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService,
            CreateSubjectProgramModel model) : base(repositoryProvider, authorizedUserService)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var curentLeqcurerId = _authorizedUserService.GetCurrentLecturerId();
            var validate = await _repositoryProvider.LecturersSubject.GetQueryable()
                .AnyAsync(x => x.LecturerId == curentLeqcurerId && x.SubjectId == _model.SubjectId); 
            
            if (validate == false) 
            {
                return Result.Error("კავშირი ვერ მოიძებნა");
            }




            var subjectProgram = new SubjectProgram()
            {
                Description = _model.Description,
                BookName = _model.BookName,
                BookPages = _model.BookPages,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                SubjectId = _model.SubjectId,

            };


            _repositoryProvider.SubjectProgrames.Create(subjectProgram);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success(subjectProgram);

        }
    }
}
