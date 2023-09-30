using University.Domain.Core;
using University.Domain.Entities.Exams;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.LecturerSubjects;
using University.Domain.Entities.StudentSubjects;
using University.Domain.Entities.SubjectPrograms;

namespace University.Domain.Entities.Subjects
{
    public class Subject : EntityBase
    {

        public string Name { get; set; }
        public string Description { get; set; }


        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<LecturerSubject> Lecturers { get; set;}
        public List<Exam> Exams { get; set; }
        public List<SubjectProgram> SubjectPrograms { get; set;}
        public List<StudentSubject> Students { get; set; }

    }
}
