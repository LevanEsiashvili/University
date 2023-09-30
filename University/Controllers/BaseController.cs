using Microsoft.AspNetCore.Mvc;
using University.Domain.Contracts;
using University.Infrastructure;

namespace University.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected RepositoryProvider _repositoryProvider;
        protected IAuthorizedUserService _authorizedUserService;

        public BaseController(RepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        public BaseController(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService)
        {
            _repositoryProvider = repositoryProvider;
            _authorizedUserService = authorizedUserService;
        }
    }
}
