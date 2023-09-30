using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Exams;

namespace University.Infrastructure.Database.Mapping
{
    public static class ExamMap
    {
        public static void ConfigureExam(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Exam>();

            entity.ToTable(nameof(Exam), "core");

            entity.HasKey(x => x.Id);
            entity.Property(X=>X.Id).ValueGeneratedNever();
            entity.HasOne(x=> x.Subject).WithMany(x => x.Exams).HasForeignKey(x => x.SubjectId);
            entity.HasOne(x=> x.Lecturer).WithMany().HasForeignKey(x=>x.LecturerId);    


        }
    }
}
