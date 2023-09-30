using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.Lecturers;

namespace University.Infrastructure.Database.Mapping
{
    public static class LecturerMap
    {
        public static void ConfigureLecturer(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Lecturer>();

            entity.ToTable(nameof(Lecturer), "core");
            entity.HasKey(x => x.Id);
            entity.Property(x=> x.Id ).ValueGeneratedNever();
            entity.Property(x=> x.QualificationYare).IsRequired();
            entity.Property(x=> x.Profession).HasMaxLength(30).IsRequired();

            
            






        }
    }
}
