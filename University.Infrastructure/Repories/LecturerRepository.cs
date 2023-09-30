using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.Lecturers;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class LecturerRepository : GenerycRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
