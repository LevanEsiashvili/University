using Microsoft.EntityFrameworkCore;
using University.Infrastructure;
using University.Query.ViewModels.GetSubjectVIewModels;
using University.Query.ViewModels.LecturerViewModels;
using University.Shared.Models;

namespace University.Query.Queries.LecturersQueries
{

    public class GetLecturerWhithSubjectQuery : QueryBase
    {
        private readonly Guid _lecturerId;

        public GetLecturerWhithSubjectQuery(RepositoryProvider repositoryProvider, Guid lecturerId) : base(repositoryProvider)
        {
            _lecturerId = lecturerId;
        }

        public override async Task<Result> HandleAsync()
        {
            var lecturer = await _repositoryProvider.Lecturers.GetQueryable()
                .Include(x => x.User)
                .Include(x => x.Subjects)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == _lecturerId);

            if (lecturer == null)
                return Result.Error("ლექტორი ვერ მოიძებნა");

            var vm = new LecturerWithSubjectVm()
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

            };

            return Result.Success(vm);
        }
    }
}
