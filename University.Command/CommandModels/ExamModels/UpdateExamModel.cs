using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Exams;

namespace University.Command.CommandModels.ExamModels
{
    public class UpdateExamModel
    {
        public Guid Id { get; set; }
        public ExameType Type { get; set; }

        public double MinimalResult { get; set; }

        public int MaximalResult { get; set; }
        public Guid LecturerId { get; set; }


        public Guid SubjectId { get; set; }
    }
}
