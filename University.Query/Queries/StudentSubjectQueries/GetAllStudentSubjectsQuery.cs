using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class GetAllStudentSubjectsQuery : QueryBase
    {

        public GetAllStudentSubjectsQuery(RepositoryProvider repositoryProvider
            , IAuthorizedUserService authorizedUserService) : base(repositoryProvider, authorizedUserService)
        {

        }

        public override async Task<Result> HandleAsync()
        {
            var studentId = _authorizedUserService.GetCurrentStudentId();

            var studentSubjectExam = await _repositoryProvider.StudentSubjects.GetQueryable()
                .Where(x => x.SubjectId == studentId)
                .Include(x => x.Subject)
                .ThenInclude(x => x.Exams)
                .Select(x => new GetAllStudentSubjectViewModel()
                {
                    Id = x.Id,
                    RegistrationDate = x.RegistrationDate,
                    Type = x.Type,
                    subjectwithExams = new subjectwithExamsViewModel
                    {
                        Id = x.Id,
                        Name = x.Subject.Name,
                        Description = x.Subject.Description,
                        GetExams = x.Subject.Exams.Select(x => new GetExamsViewModels()
                        {
                            Id = x.Id,
                            Type = x.Type,
                            MinimalResult = x.MinimalResult,
                            MaximalResult = x.MaximalResult,



                        }).ToList(),


                    }

                }).ToListAsync();

            return Result.Success(studentSubjectExam);

        }
    }
}
