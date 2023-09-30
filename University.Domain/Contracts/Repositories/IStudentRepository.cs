using University.Domain.Contracts.Repositories.Base;
using University.Domain.Entities.Students;

namespace University.Domain.Contracts.Repositories
{
    public interface IStudentRepository : IGenerycRepository<Student>
    {
    }
}
