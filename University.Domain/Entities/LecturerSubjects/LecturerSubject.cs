using University.Domain.Core;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Subjects;

namespace University.Domain.Entities.LecturerSubjects
{
    public class LecturerSubject : EntityBase
    {
        public Guid LecturerId { get; set; }
        public Guid SubjectId { get; set; }
        public Lecturer Lecturer { get; set; }
        public Subject Subject { get; set; }
    }
}

