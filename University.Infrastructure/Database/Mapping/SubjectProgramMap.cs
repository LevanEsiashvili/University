using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.SubjectPrograms;

namespace University.Infrastructure.Database.Mapping
{
    public static class SubjectProgramMap
    {
        public static void ConfigureSubjectProgram(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SubjectProgram>();

            entity.ToTable(nameof(SubjectProgram), "core");

            entity.HasKey(x=> x.Id);
            entity.Property(x=>x.Id ).ValueGeneratedNever();
            entity.Property(x=> x.BookName).HasMaxLength(30).IsRequired();
            entity.Property(x=>x.Description ).IsRequired();
            entity.Property(x=>x.StartTime).IsRequired();
            entity.Property(x=>x.EndTime).IsRequired();
            entity.HasOne(x => x.Subject)
                .WithMany(x => x.SubjectPrograms)
                .HasForeignKey(x => x.SubjectId);


            



        }
    }
}
