using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Faculties;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Users;

namespace University.Infrastructure.Database.Mapping
{
    public static class UserMap
    {
        public static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.ToTable(nameof(User), "core");

            entity.HasKey(x => x.Id);
            entity.Property(x=> x.Id).ValueGeneratedNever();

            entity.Property(x=> x.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(50).IsRequired();
            entity.Property(x => x.PrivateNumber).HasMaxLength(50).IsRequired();
            entity.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired();
            entity.Property(x => x.BirtsDate).IsRequired();
                
            entity.HasOne(x=> x.Student).WithOne(x=> x.User).HasForeignKey <User>(x=> x.StudentId);
            entity.HasOne(x => x.Lecturer).WithOne(x=> x.User).HasForeignKey<User>(x => x.LecturerId);

        }

    }
}
