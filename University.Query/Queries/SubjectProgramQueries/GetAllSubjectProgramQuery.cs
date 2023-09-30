using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.FacultyViewModels;
using University.Query.ViewModels.SubjectProgramViewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectProgramQueries
{
    public class GetAllSubjectProgramQuery : QueryBase
    {
        public GetAllSubjectProgramQuery(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override async Task<Result> HandleAsync()
        {
            var SubjectProgram = await _repositoryProvider.SubjectProgrames.GetQueryable().Where(x=> !x.IsDeleted)
                .Select(x => new GetCreateSubjectProgramViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                BookName = x.BookName,
                BookPages = x.BookPages,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                SubjectId = x.SubjectId,
                
                
            }).ToListAsync();

            return Result.Success(SubjectProgram);

        }
    }
}
