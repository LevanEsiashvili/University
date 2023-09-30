using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories.Base;
using University.Domain.Entities.Exams;
using University.Domain.Entities.StudentSubjectExams;

namespace University.Domain.Contracts.Repositories
{
    public interface IStudentSubjectExamRepository : IGenerycRepository<StudentSubjectExam>
    {
    }
}
