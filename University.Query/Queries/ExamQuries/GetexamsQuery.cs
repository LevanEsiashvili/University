using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.ExamViewModels;
using University.Shared.Models;

namespace University.Query.Queries.ExamQuries
{
    public class GetexamsQuery : QueryBase
    {
        private readonly Guid _subjectId;
        
        public GetexamsQuery(RepositoryProvider repositoryProvider, Guid subjectId) : base(repositoryProvider)
        {
            _subjectId = subjectId;
        }

        public override async Task<Result> HandleAsync()
        {
            var exmas = await _repositoryProvider.Exams.GetQueryable().Where(x => x.SubjectId == _subjectId)
                .Select(x => new GetExamsViewModels()
                {
                    Id = x.Id,
                    Type = x.Type,
                    MinimalResult = x.MinimalResult,
                    MaximalResult = x.MaximalResult,
                }).ToListAsync();

            return Result.Success(exmas);
        }
    }
}
