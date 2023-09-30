using University.Domain.Core;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.StudentSubjectExams;
using University.Domain.Entities.Subjects;

namespace University.Domain.Entities.Exams
{
    public class Exam :EntityBase
    {
        

        public ExameType Type { get; set; }

        public double MinimalResult { get; set; }

        public int MaximalResult { get; set; }

        public Guid LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        

    }
}
