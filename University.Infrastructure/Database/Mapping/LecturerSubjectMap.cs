using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.LecturerSubjects;

namespace University.Infrastructure.Database.Mapping
{
    public static class LecturerSubjectMap
    {
        public static void ConfigureLecturerSubject(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<LecturerSubject>();

            entity.ToTable(nameof(LecturerSubject), "core");

            entity.HasKey(x => x.Id );
            entity.Property(X=>X.Id ).ValueGeneratedNever();

            entity.HasOne(x => x.Lecturer).WithMany(x=> x.Subjects).HasForeignKey(x => x.LecturerId);
            entity.HasOne(x=> x.Subject).WithMany(x=> x.Lecturers).HasForeignKey(x=> x.SubjectId);


        }
    }
}
