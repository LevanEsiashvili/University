using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.AuthModels
{
    public class RegisterStudentCommandModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtsDate { get; set; }
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string GraduatedSchool { get; set; }
        public double GPA { get; set; }
        public Guid FacultyId { get; set; }

    }
}
