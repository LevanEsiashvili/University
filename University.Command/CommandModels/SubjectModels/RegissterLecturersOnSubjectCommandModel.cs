using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.SubjectModels
{
    public class RegissterLecturersOnSubjectCommandModel
    {
        public Guid LecturerId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
