using University.Domain.Core;
using University.Domain.Entities.Students;
using University.Domain.Entities.StudentSubjectExams;
using University.Domain.Entities.Subjects;

namespace University.Domain.Entities.StudentSubjects
{
    public class StudentSubject: EntityBase
    {
        
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }

        public StudentSubjectType Type { get; set; }

        public DateTime RegistrationDate { get; set; }


        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public List<StudentSubjectExam> StudentSubjectExams { get; set; }

    }
}
