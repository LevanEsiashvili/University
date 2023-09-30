using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Entities.Students;
using University.Domain.Entities.Subjects;

namespace University.Domain.Entities.Faculties
{
    public class Faculty : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }
    }
}
