using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Query.ViewModels.ExamViewModels;

namespace University.Query.ViewModels.GetSubjectVIewModels
{
    public class subjectwithExamsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GetExamsViewModels> GetExams { get; set; }
    }
}
