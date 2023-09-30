using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities.Users;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.CommandModels.UserModels
{
    public class UserRegistration : CommandBase
    {
        public UserRegistration(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        public override Task<Result> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
