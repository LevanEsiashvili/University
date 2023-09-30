using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Entities.LecturerSubjects;
using University.Domain.Entities.Users;

namespace University.Domain.Entities.Lecturers
{
    public class Lecturer : EntityBase
    {
        public int QualificationYare { get; set; }
        public string Profession { get; set; }
        
        
        public User User { get; set; }


        public List<LecturerSubject> Subjects { get; set; }

    }
}
