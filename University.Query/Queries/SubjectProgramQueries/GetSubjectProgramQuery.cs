using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Query.Queries.SubjectProgramQueries
{
    public class GetSubjectProgramQuery : QueryBase
    {
        private readonly Guid _subjectId;
        public GetSubjectProgramQuery(RepositoryProvider repositoryProvider, Guid subjectid) : base(repositoryProvider)
        {
            _subjectId = subjectid;
        }

        public override Task<Result> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
