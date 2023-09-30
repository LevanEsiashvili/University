using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.StudentSubjects;

namespace University.Infrastructure.Database.Mapping
{
    public static class StudentSubjectMap
    {
        public static void ConfigureStudentSubject(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<StudentSubject>();

            entity.ToTable(nameof(StudentSubject), "core");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedNever();



            
            entity.Property(x => x.RegistrationDate).IsRequired();
            entity.HasOne(x=> x.Student).WithMany(x=>x.Subjects).HasForeignKey(x=>x.StudentId);
            entity.HasOne(x=>x.Subject).WithMany(x=>x.Students).HasForeignKey(x=>x.SubjectId);


        }

    }
}
