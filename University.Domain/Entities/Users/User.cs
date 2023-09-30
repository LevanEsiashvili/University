using University.Domain.Core;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.LecturerSubjects;
using University.Domain.Entities.Students;
using University.Domain.Entities.StudentSubjects;
using University.Shared.Enumes;

namespace University.Domain.Entities.Users
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtsDate { get; set; }
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }


        public Guid? StudentId { get; set; }

        public Student Student { get; set; }

        public Guid? LecturerId { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
