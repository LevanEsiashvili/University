using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.StudentSubjects;
using University.Domain.Entities.SubjectPrograms;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class SubjectProgramRepository : GenerycRepository<SubjectProgram>, ISubjectProgramRepository
    {
        public SubjectProgramRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
