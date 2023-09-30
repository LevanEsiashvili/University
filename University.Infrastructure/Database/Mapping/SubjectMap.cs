using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Subjects;

namespace University.Infrastructure.Database.Mapping
{
    public static class SubjectMap
    {
        public static void ConfigureSubject (this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Subject>();
            entity.ToTable(nameof(Subject), "core");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedNever();
            entity.Property(x=> x.Name).HasMaxLength(50).IsRequired();
            entity.Property(x=> x.Description).IsRequired();

            entity.HasOne(x=> x.Faculty).WithMany(x=> x.Subjects).HasForeignKey(x=>x.FacultyId).OnDelete(DeleteBehavior.Cascade);
            

        }
   
    }
}
