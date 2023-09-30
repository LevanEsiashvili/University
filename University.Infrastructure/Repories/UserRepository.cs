using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Contracts.Repositories;
using University.Domain.Entities.Users;
using University.Infrastructure.Database;
using University.Infrastructure.Repories.Base;

namespace University.Infrastructure.Repories
{
    public class UserRepository : GenerycRepository<User>, IUserRepository
    {
        public UserRepository(UniversityDbContext context) : base(context)
        {
        }
    }
}
