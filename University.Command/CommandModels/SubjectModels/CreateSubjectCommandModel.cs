using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.SubjectModels
{
    public class CreateSubjectCommandModel
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public Guid FacultyId { get; set; }
    }
}
