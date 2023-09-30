using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.Exams;
using University.Domain.Entities.Faculties;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class ExamRepository : GenerycRepository<Exam>, IExamRepository
    {
        public ExamRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
