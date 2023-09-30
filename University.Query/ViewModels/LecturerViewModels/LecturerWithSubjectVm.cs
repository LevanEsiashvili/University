using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Query.ViewModels.GetSubjectVIewModels;

namespace University.Query.ViewModels.LecturerViewModels
{
    public class LecturerWithSubjectVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<SubjectVm> Subjects { get; set; }
    }
}
