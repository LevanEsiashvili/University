using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetAllSubjectQuery : QueryBase
    {
        public GetAllSubjectQuery(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override async Task<Result> HandleAsync()
        {
            var subjects = await _repositoryProvider.Subjects.GetQueryable().ToListAsync();

            if (subjects == null)
            {
               return Result.Success("საგნები არ მოიძებნა");
            }

            var subjectvm = new List<SubjectVm>();

            foreach (var subject in subjects)
            {

                subjectvm.Add(new SubjectVm()
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                });


            }

            return Result.Success(subjectvm);

            
        }
    }
}
