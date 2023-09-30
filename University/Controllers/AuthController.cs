using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.AuthModels;
using University.Command.Commands.AuthCommands;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Shared.Enumes;
using University.WebApi.Service;

namespace University.WebApi.Controllers
{
    [ApiController]
    [Route(nameof(AuthController))]
    public class AuthController : BaseController
    {
        public AuthController(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService) : base(repositoryProvider, authorizedUserService)
        {
        }

        [Authorize(Role.Admin)]
        [HttpPost("lecturer-registration")]
        public async Task<IActionResult> LecturerRegistration(RegisterLecturerCommandModel model)
        {
            var command = new RegisterLecturerCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());
        }

        [Authorize(Role.Admin)]
        [HttpPost("Student-registration")]
        public async Task<IActionResult> StudentRegistration(RegisterStudentCommandModel model)
        {
            var command = new RegisterStudentCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommandModel model)
        {
            var command = new LoginUserCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());
        }
    }
}
