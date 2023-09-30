using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.StudentSubjectExamCommandModels;
using University.Domain.Contracts;
using University.Domain.Entities.StudentSubjectExams;
using University.Domain.Entities.StudentSubjects;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.StudentSubjectExamCommands
{
    public class StudentAssessmentCommand : CommandBase
    {
        private readonly StudentAssessmentCommandModel _model;
        public StudentAssessmentCommand(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService,
            StudentAssessmentCommandModel model) : base(repositoryProvider, authorizedUserService)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var lecturerid = _authorizedUserService.GetCurrentLecturerId();

            var lecturerSubject = _repositoryProvider.Exams.GetQueryable()
               .FirstOrDefault(x =>  x.LecturerId == lecturerid && x.Id == _model.ExamId && !x.IsDeleted);

            if (lecturerSubject == null)
            {
                return Result.Error(" ვერ მოიძებნა");

            }

            var studentSubject = await _repositoryProvider.StudentSubjects.GetQueryable()
                .FirstOrDefaultAsync(x => x.SubjectId == _model.subjectId && x.StudentId == _model.studentId);

            if (studentSubject == null)
            {
                return Result.Error(" ვერ მოიძებნა");

            }

            var result = new StudentSubjectExam()
            {
                Type = lecturerSubject.Type,
                Result = _model.Result,
                StudentSubjectId = studentSubject.Id,


            };

            _repositoryProvider.StudentSubjectExames.Create(result);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success("ნიშანი დაიწერა");

            

        }
    }
}
