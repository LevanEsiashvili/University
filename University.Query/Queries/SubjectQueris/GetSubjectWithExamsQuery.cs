using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Query.ViewModels.ExamViewModels;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetSubjectWithExamsQuery : QueryBase
    {
        private readonly Guid _subjectId;
        public GetSubjectWithExamsQuery(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService, Guid subjectId) : base(repositoryProvider, authorizedUserService)
        {
            _subjectId = subjectId;
        }

        public override async Task<Result> HandleAsync()
        {
            var lecturerId = _authorizedUserService.GetCurrentLecturerId();

            var lecturerSubject = _repositoryProvider.LecturersSubject.GetQueryable()
                .Any(x => x.SubjectId == _subjectId && x.LecturerId == lecturerId && !x.IsDeleted);

            if (lecturerSubject == false)
            {
                return Result.Error("საგანი ვერ მოიძებნა");

            }

            var subject = await _repositoryProvider.Subjects.GetQueryable()
                .Include(x=> x.Exams ).FirstOrDefaultAsync(X=> X.Id == _subjectId && !X.IsDeleted);

            if (subject ==  null)
            {
                return Result.Error("საგანი ვერ მოიძებნა");

            }

            var subjectExams = new GetSubjectWithExamsVm()
            {
                Id = _subjectId,
                Name = subject.Name,
                Description = subject.Description,
                Exams = subject.Exams.Select(x => new ExamVm()
                {
                    Id = x.Id,
                    Type = x.Type,
                    MinimalResult = x.MinimalResult,
                    MaximalResult = x.MaximalResult,

                }).ToList(),

            };

            return Result.Success(subjectExams);    






        }
    }
}
