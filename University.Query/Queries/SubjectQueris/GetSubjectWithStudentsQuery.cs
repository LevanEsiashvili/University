using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.StudentViewModels;
using University.Shared.Models;

namespace University.Query.Queries.SubjectQueris
{
    public class GetSubjectWithStudentsQuery : QueryBase
    {
        public Guid _subjectId { get; set; }    
        public GetSubjectWithStudentsQuery(RepositoryProvider repositoryProvider
            ,IAuthorizedUserService authorizedUserService,Guid id) : base(repositoryProvider,authorizedUserService)
        {
            _subjectId = id;
        }

        public override async Task<Result> HandleAsync()
        {
            var lecturerId = _authorizedUserService.GetCurrentLecturerId();

            var lecturerSubject = _repositoryProvider.LecturersSubject.GetQueryable()
                .Any(x => x.SubjectId == _subjectId && x.LecturerId == lecturerId && !x.IsDeleted);

            if (lecturerSubject == false )
            {
                return Result.Error("საგანი ვერ მოიძებნა");

            }




            var subject = await _repositoryProvider.Subjects.GetQueryable()
                .Include(x => x.Students).ThenInclude(x => x.Student)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == _subjectId);


            if (subject == null)
            {
                return Result.Error("საგანი ვერ მოიძებნა");
            }

            var subjectStudents = new GetSubjectWithStudentsVm()
            {
                Id = _subjectId,
                Name = subject.Name,
                Description = subject.Description,
                Students = subject.Students.Select(x => new GetStudentsVm()
                {
                    id = x.Id,
                    FirstName = x.Student.User.FirstName,
                    LastName = x.Student.User.LastName,
                    Email = x.Student.User.Email,
                    PhoneNumber = x.Student.User.PhoneNumber,
                    PrivateNumber = x.Student.User.PrivateNumber,

                }).ToList(),
            };

            return Result.Success(subjectStudents);


        }
    }
}
