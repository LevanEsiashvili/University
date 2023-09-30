using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Query.ViewModels.StudentViewModels;

namespace University.Query.ViewModels.GetSubjectVIewModels
{
    public class GetSubjectWithStudentsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GetStudentsVm> Students { get; set; }

    }
}
