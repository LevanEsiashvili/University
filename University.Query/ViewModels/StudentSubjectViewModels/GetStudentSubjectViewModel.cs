using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.StudentSubjects;
using University.Query.ViewModels.GetSubjectVIewModels;

namespace University.Query.ViewModels.StudentSubjectViewModels
{
    internal class GetStudentSubjectViewModel
    {
        public Guid Id { get; set; }
        public StudentSubjectType Type { get; set; }

        public DateTime RegistrationDate { get; set; }

        public subjectwithExamsViewModel subjectwithExams { get; set; }
    }
}
