using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.Students;
using University.Domain.Entities.StudentSubjectExams;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class StudentSubjectExamRepository : GenerycRepository<StudentSubjectExam>, IStudentSubjectExamRepository
    {
        public StudentSubjectExamRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
