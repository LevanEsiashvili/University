using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.SubjectProgramModels
{
    public class UpdateSubjectProgramModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string BookName { get; set; }
        public string BookPages { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        
    }
}
