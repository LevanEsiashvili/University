using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Entities.Subjects;

namespace University.Domain.Entities.SubjectPrograms
{
    public class SubjectProgram: EntityBase
    {
        public string Description { get; set; }
        public string BookName { get; set; }
        public string BookPages { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
