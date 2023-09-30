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
    public class GetFacultyQuery : QueryBase
    {
        private readonly Guid _id;

        public GetFacultyQuery(RepositoryProvider repositoryProvider, Guid id) : base(repositoryProvider)
        {
            _id = id;
        }

        public override async Task<Result> HandleAsync()
        {
            var faculty = await _repositoryProvider.Faculties.GetQueryable().FirstOrDefaultAsync(x=>x.Id == _id && !x.IsDeleted);

            if(faculty == null)
            {
               return Result.Error("ფაკულტეტი ვერ მოიძებნა");
            }

            var responceModel = new FacultyVm()
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Description = faculty.Description,
            };

            return Result.Success(responceModel);
        }
    }
}
