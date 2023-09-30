using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Core;
using University.Domain.Entities.Exams;
using University.Domain.Entities.StudentSubjects;

namespace University.Domain.Entities.StudentSubjectExams
{
    public class StudentSubjectExam :EntityBase
    {
        public ExameType Type { get; set; }

        public double Result { get; set; }

        public Guid StudentSubjectId { get; set; }

        public StudentSubject StudentSubject { get; set; }

        public Guid ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}
