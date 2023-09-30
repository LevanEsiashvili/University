using SimpleSoft.Mediator;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Query
{
    public abstract class QueryBase
    {
        protected RepositoryProvider _repositoryProvider { get; }
        protected IAuthorizedUserService _authorizedUserService { get; }

        public QueryBase(RepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        protected QueryBase(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService)
        {
            _repositoryProvider = repositoryProvider;
            _authorizedUserService = authorizedUserService;
        }

        public abstract Task<Result> HandleAsync();
    }
}
