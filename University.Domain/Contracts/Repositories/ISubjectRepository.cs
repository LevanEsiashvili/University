using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories.Base;
using University.Domain.Entities.SubjectPrograms;
using University.Domain.Entities.Subjects;

namespace University.Domain.Contracts.Repositories
{
    public interface ISubjectRepository : IGenerycRepository<Subject>
    {
    }
}
