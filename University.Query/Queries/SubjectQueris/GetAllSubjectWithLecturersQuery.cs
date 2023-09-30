using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Users;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.LecturerViewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetAllSubjectWithLecturersQuery : QueryBase
    {
        public GetAllSubjectWithLecturersQuery(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override async Task<Result> HandleAsync()
        {
            var SubjectWitthLecturers = await _repositoryProvider.Subjects.GetQueryable().Include(x => x.Lecturers)
                .ThenInclude(x => x.Lecturer).ThenInclude(x => x.User)

                .Select(x => new SubjectsWithLecturersVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,

                    lecturers = x.Lecturers.Select(z => new LecturerVm()
                    {
                        Id = z.Lecturer.Id,
                        FirstName = z.Lecturer.User.FirstName,
                        LastName = z.Lecturer.User.LastName,
                        Email = z.Lecturer.User.Email,
                        PhoneNumber = z.Lecturer.User.PhoneNumber



                    }).ToList(),





                }).ToListAsync();


            return Result.Success(SubjectWitthLecturers);


        }
    }
}
