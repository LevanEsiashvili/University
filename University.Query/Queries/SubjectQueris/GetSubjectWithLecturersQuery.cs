using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.LecturerViewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetSubjectWithLecturersQuery : QueryBase
    {   public Guid _id { get; set; }
        public GetSubjectWithLecturersQuery(RepositoryProvider repositoryProvider, Guid id) : base(repositoryProvider)
        {
            _id = id;
        }

        public override async Task<Result> HandleAsync()
        {
            var subjectWithlecurers =  await _repositoryProvider.Subjects.GetQueryable()
                .Include(x=> x.Lecturers).ThenInclude(x=> x.Lecturer).ThenInclude(x=> x.User)
                .FirstOrDefaultAsync(x=> x.Id == _id);

            if (subjectWithlecurers == null)
            {
                return Result.Success("ასეთი საგანი არ არსებობს ");

            }

            SubjectsWithLecturersVm subjectsWithLecturersVm = new()
            {
                Id = subjectWithlecurers.Id,
                Name = subjectWithlecurers.Name,
                Description = subjectWithlecurers.Description,
                lecturers = subjectWithlecurers.Lecturers.Select(x=> new LecturerVm()
                {
                    Id = x.Lecturer.Id,
                    FirstName = x.Lecturer.User.FirstName,
                    LastName = x.Lecturer.User.LastName,
                    Email = x.Lecturer.User.Email,
                    PhoneNumber =x.Lecturer.User.PhoneNumber

                }).ToList()

            };

            return Result.Success(subjectsWithLecturersVm);

        }
    }
}
