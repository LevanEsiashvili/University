using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.ExamViewModels;
using University.Shared.Models;

namespace University.Query.Queries.ExamQuries
{
    public class GetexamQuery : QueryBase
    {
        public Guid Id { get; set; }
        public GetexamQuery(RepositoryProvider repositoryProvider, Guid id) : base(repositoryProvider)
        {
            Id = id;
        }

        public override async Task<Result> HandleAsync()
        {
           var exam = await  _repositoryProvider.Exams.GetQueryable().FirstOrDefaultAsync(X=> X.Id == Id);

            if (exam == null)
            {
                return Result.Success("ვერ მოიძებნა გამოცდა");
            }

            var getExam = new GetExamViewModels
            {
                Id = exam.Id,
                Type = exam.Type,
                MinimalResult = exam.MinimalResult,
                MaximalResult = exam.MaximalResult,
                LecturerId = exam.LecturerId,
                SubjectId = exam.SubjectId,
            };

            return Result.Success(getExam);
        }
    }
}
