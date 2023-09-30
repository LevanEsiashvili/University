using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts;
using University.Domain.Contracts.Repositories;
using University.Infrastructure.Repories;

namespace University.Infrastructure
{
    public class RepositoryProvider
    {
        

        public IUnitOfWork UnitOfWork { get;}
        public IStudentRepository Students { get; }
        public IExamRepository Exams { get; }
        public IFacultyRepository Faculties { get; }
        public ILecturerRepository Lecturers{ get; }
        public IStudentSubjectExamRepository StudentSubjectExames { get; }
        public IStudentSubjectRepository StudentSubjects { get; }
        public ISubjectProgramRepository SubjectProgrames { get; }
        public ISubjectRepository Subjects { get; }
        public IUserRepository Users { get; }
        public ILecturerSubjectRepository LecturersSubject { get; }

        public RepositoryProvider(IUnitOfWork unitOfWork,
            IStudentRepository students,
            IExamRepository exams,
            IFacultyRepository faculties,
            ILecturerRepository lecturers,
            IStudentSubjectExamRepository studentSubjectExames,
            IStudentSubjectRepository studentSubjects,
            ISubjectProgramRepository subjectProgrames,
            ISubjectRepository subjects,
            IUserRepository users,
            ILecturerSubjectRepository lecturersSubject)
        {
            UnitOfWork = unitOfWork;
            Students = students;
            Exams = exams;
            Faculties = faculties;
            Lecturers = lecturers;
            StudentSubjectExames = studentSubjectExames;
            StudentSubjects = studentSubjects;
            SubjectProgrames = subjectProgrames;
            Subjects = subjects;
            Users = users;
            LecturersSubject = lecturersSubject;
        }

    }
}
