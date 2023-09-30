using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.SubjectModels;
using University.Domain.Entities.LecturerSubjects;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.SubjectCommands
{
    public class RegissterLecturersOnSubjectCommand : CommandBase
    {
        public readonly RegissterLecturersOnSubjectCommandModel _model;
        public RegissterLecturersOnSubjectCommand(RepositoryProvider repositoryProvider,RegissterLecturersOnSubjectCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {

           
           var Lecturer = await _repositoryProvider.Lecturers.GetQueryable().FirstOrDefaultAsync(x=> x.Id ==  _model.LecturerId);

            if (Lecturer == null)
            {
                return Result.Success("ლექტორი ვერ მოიძებნა");
            }

            var subject = _repositoryProvider.Subjects.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _model.SubjectId);
            if (subject == null)
            {
                return Result.Success("საგანი ვერ მოიძებნა");
                
            }

            var old = await _repositoryProvider.LecturersSubject.GetQueryable()
              .FirstOrDefaultAsync(x => x.SubjectId == _model.SubjectId && x.LecturerId == _model.LecturerId);

            if (old != null)
            {
                return Result.Success("საგანზე ლექტორი უკვე დარეგისტრირებულია");
            }


            var lecturerSubject = new LecturerSubject()
            {
                SubjectId = _model.SubjectId,
                LecturerId = _model.LecturerId,

            };

            



            _repositoryProvider.LecturersSubject.Create(lecturerSubject);

            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success("წარმატებით დაემატა");









        }
    }


}
