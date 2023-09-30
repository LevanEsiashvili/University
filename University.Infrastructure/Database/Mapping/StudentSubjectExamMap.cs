using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.StudentSubjectExams;

namespace University.Infrastructure.Database.Mapping
{
    public static class StudentSubjectExamMap
    {
        public static void ConfigureStudentSubjectExam(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<StudentSubjectExam>();

            entity.ToTable(nameof(StudentSubjectExam), "core");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedNever();

            entity.HasOne(x => x.StudentSubject)
                .WithMany(x => x.StudentSubjectExams)
                .HasForeignKey(x => x.StudentSubjectId)
                .IsRequired();

            entity.HasOne(x => x.Exam)
                .WithOne()
                .HasForeignKey<StudentSubjectExam>(x => x.ExamId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();






        }
    }
}
