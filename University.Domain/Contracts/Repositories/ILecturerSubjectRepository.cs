using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories.Base;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.LecturerSubjects;

namespace University.Domain.Contracts.Repositories
{
    public interface ILecturerSubjectRepository : IGenerycRepository<LecturerSubject>
    {
    }
}
