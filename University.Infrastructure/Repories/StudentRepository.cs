using University.Domain.Contracts.Repositories;
using University.Domain.Entities.Students;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class StudentRepository : GenerycRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext context) : base(context)
        {
        }

    }
}
