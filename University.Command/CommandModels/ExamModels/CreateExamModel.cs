using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Exams;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Subjects;

namespace University.Command.CommandModels.ExamModels
{
    public class CreateExamModel
    {
        public ExameType Type { get; set; }

        public double MinimalResult { get; set; }

        public int MaximalResult { get; set; }
        public Guid LecturerId { get; set; }
       

        public Guid SubjectId { get; set; }
        

    }
}
