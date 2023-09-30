using SimpleSoft.Mediator;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command
{
    public abstract class CommandBase
    {
        protected RepositoryProvider _repositoryProvider { get; }
        protected IAuthorizedUserService _authorizedUserService { get; }

        public CommandBase(RepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        protected CommandBase(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService)
        {
            _repositoryProvider = repositoryProvider;
            _authorizedUserService = authorizedUserService;
        }

        public abstract Task<Result> HandleAsync();
    }
}
