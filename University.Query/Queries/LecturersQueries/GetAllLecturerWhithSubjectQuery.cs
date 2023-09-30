using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Lecturers;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.LecturerViewModels;
using University.Shared.Models;

namespace University.Query.Queries.LecturersQueries{

    public class GetAllLecturerWhithSubjectQuery : QueryBase
    {
        public GetAllLecturerWhithSubjectQuery(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override async Task<Result> HandleAsync()
        {
            //throw new NotImplementedException();

            var leqturers = await _repositoryProvider.Lecturers.GetQueryable()
                .Include(x=> x.User)
                .Include(x=> x.Subjects)
                .ThenInclude(x=> x.Subject).Select(lecturer => new LecturerWithSubjectVm()
                {
                    Id = lecturer.Id,
                    FirstName = lecturer.User.FirstName,
                    LastName = lecturer.User.LastName,
                    PhoneNumber = lecturer.User.PhoneNumber,
                    Email = lecturer.User.Email,
                    Subjects = lecturer.Subjects.Select(s => new SubjectVm()
                    {
                        Id = s.Subject.Id,
                        Name = s.Subject.Name,
                        Description = s.Subject.Description,
                    }).ToList(),

                }).ToListAsync();

            return Result.Success(leqturers);
        }
    }
}
