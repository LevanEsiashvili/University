using University.Domain.Core;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.StudentSubjects;
using University.Domain.Entities.Users;

namespace University.Domain.Entities.Students
{
    public class Student : EntityBase
    {
        public string? GraduatedSchool { get; set; }

        public double GPA { get; set; }

        
        public User User { get; set; }


        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<StudentSubject> Subjects { get; set; }
    }
}
