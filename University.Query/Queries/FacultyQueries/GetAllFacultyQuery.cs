using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.FacultyViewModels;
using University.Shared.Models;

namespace University.Query.Queries.FacultyQueries
{
    public class GetAllFacultyQuery : QueryBase
    {
        public GetAllFacultyQuery(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override async Task<Result> HandleAsync()
        {
            var faculties = await _repositoryProvider.Faculties.GetQueryable().Select(x => new FacultyVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();

            if (faculties == null)
            {
               return Result.Error("ფაკულტეტები ვერ მოიძებნა");
            }

            return  Result.Success(faculties);

        }
    }
}
