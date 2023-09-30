using Microsoft.EntityFrameworkCore;

namespace University.Infrastructure.Database.Mapping
{
    public static class FacultyMap
    {
        public static void ConfigureFaculty(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Domain.Entities.Faculties.Faculty>();

            entity.ToTable(nameof(Domain.Entities.Faculties.Faculty), "core");
            entity.HasKey( x=> x.Id);
            entity.Property(x=> x.Id).ValueGeneratedNever();

            entity.Property( x => x.Name ).HasMaxLength(50).IsRequired();
            entity.Property(x=> x.Description ).IsRequired();
           


        }

    }
}
