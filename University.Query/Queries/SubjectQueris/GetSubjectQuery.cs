using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetSubjectQuery : QueryBase
    {
        private readonly Guid _Id;
        public GetSubjectQuery(RepositoryProvider repositoryProvider, Guid id ) : base(repositoryProvider)
        {
            _Id = id;
        }

        public override async Task<Result> HandleAsync()
        {
            var subject = await _repositoryProvider.Subjects.GetQueryable().FirstOrDefaultAsync(x=> x.Id == _Id && !x.IsDeleted );

            if ( subject == null )
            {
                return Result.Error("საგანი ვერ მოიძებნა");
            }

            SubjectVm subjectVm = new()
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,


            };

            return Result.Success(subjectVm);
        }
    }
}
