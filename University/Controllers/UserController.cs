using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.UserModels;
using University.Command.Commands.UserCommands;
using University.Infrastructure;

namespace University.WebApi.Controllers
{
    [ApiController]
    [Route(nameof(UserController))]
    public class UserController : BaseController
    {
       
        public UserController(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentCommandModel model)
        {
            var command = new CreateStudentCommand(_repositoryProvider,model);

            return Ok(await command.HandleAsync());
        }

        [HttpPost("CreateLecturer")]
        public async Task<IActionResult> CreateLecturer(CreateLecturerCommandModel model)
        {
            var command = new CreateLecturerCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }



    }
}
