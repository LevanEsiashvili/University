using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.SubjectPrograms;
using University.Domain.Entities.Subjects;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class SubjectRepository : GenerycRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
