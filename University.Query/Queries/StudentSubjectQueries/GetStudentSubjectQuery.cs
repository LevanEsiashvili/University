using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Query.ViewModels.ExamViewModels;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.StudentSubjectViewModels;
using University.Shared.Models;

namespace University.Query.Queries.StudentSubjectQueries
{
    public class GetStudentSubjectQuery : QueryBase
    {
        private readonly Guid _subjectId;
        public GetStudentSubjectQuery(RepositoryProvider repositoryProvider,
            IAuthorizedUserService authorizedUserService,Guid subjectid) : base(repositoryProvider,authorizedUserService)
        {
            _subjectId = subjectid;
        }

        public override async Task<Result> HandleAsync()
        {
            var studentId = _authorizedUserService.GetCurrentStudentId();

            var studentsubject = await _repositoryProvider.StudentSubjects.GetQueryable()
                .Include(x => x.Subject)
                .ThenInclude(x => x.Exams)
                .FirstOrDefaultAsync(x => x.SubjectId == _subjectId && x.StudentId == studentId);

            var studentSubjectVm = new GetStudentSubjectViewModel()
            {
                Id = studentsubject.Id,
                Type = studentsubject.Type,
                RegistrationDate = studentsubject.RegistrationDate,
                subjectwithExams = new subjectwithExamsViewModel()
                {
                    Id = studentsubject.Subject.Id,
                    Name = studentsubject.Subject.Name,
                    Description = studentsubject.Subject.Description,
                    GetExams = studentsubject.Subject.Exams.Select(x => new GetExamsViewModels()
                    {
                        Id = x.Id,
                        Type = x.Type,
                        MinimalResult = x.MinimalResult,
                        MaximalResult = x.MaximalResult,

                    }).ToList(),

                }



            };



                return Result.Success(studentSubjectVm);

        }
    }
}
