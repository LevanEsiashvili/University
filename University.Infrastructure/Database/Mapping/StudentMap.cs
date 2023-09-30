using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;

namespace University.Infrastructure.Database.Mapping
{
    public static class StudentMap
    {
        public static void ConfigureStudent(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Student>();

            entity.ToTable(nameof(Student), "core");

            entity.HasKey(t => t.Id);
            entity.Property(x => x.Id).ValueGeneratedNever();



            entity.HasOne(x=> x.Faculty).WithMany().HasForeignKey(x => x.FacultyId);
           


        }
    }
}
