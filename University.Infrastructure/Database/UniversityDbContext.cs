using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Exams;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.LecturerSubjects;
using University.Domain.Entities.Students;
using University.Domain.Entities.StudentSubjectExams;
using University.Domain.Entities.StudentSubjects;
using University.Domain.Entities.SubjectPrograms;
using University.Domain.Entities.Subjects;
using University.Domain.Entities.Users;
using University.Infrastructure.Database.Initsializers;
using University.Infrastructure.Database.Mapping;

namespace University.Infrastructure.Database
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Domain.Entities.Faculties.Faculty> Faculties { get; set; }
        public DbSet<Lecturer> lecturers { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<LecturerSubject> lecturerSubjects { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<StudentSubject> studentsSubjects { get; set; }
        public DbSet<StudentSubjectExam> StudentSubjectExams { get; set; }
        public DbSet<SubjectProgram> subjectProgrames { get; set; }
        public DbSet<User> users { get; set; }



        public UniversityDbContext(DbContextOptions<UniversityDbContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureStudent();
            modelBuilder.ConfigureFaculty();
            modelBuilder.ConfigureLecturer();
            modelBuilder.ConfigureSubject();
            modelBuilder.ConfigureLecturerSubject();
            modelBuilder.ConfigureExam();
            modelBuilder.ConfigureStudentSubjectExam();
            modelBuilder.ConfigureStudentSubject();
            modelBuilder.ConfigureSubjectProgram();
            modelBuilder.ConfigureUser();


            modelBuilder.InitializeUser();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
