using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.StudentSubjectExamCommandModels
{
    public class StudentAssessmentCommandModel
    {
        public Guid studentId { get; set; }
        public Guid subjectId { get; set; }
        public Guid ExamId { get; set; }
        public double Result { get; set; }


    }
}
