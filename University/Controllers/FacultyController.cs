using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.FacultyModels;
using University.Command.Commands.FacultyCommands;
using University.Infrastructure;
using University.Query.Queries.FacultyQueries;
using University.Shared.Enumes;
using University.WebApi.Service;

namespace University.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route(nameof(FacultyController))]

    public class FacultyController : BaseController
    {
        public FacultyController(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        [Authorize(Role.Admin)]
        [HttpPost("CreateFaculty")]
        public async Task<IActionResult> CreateFaculty(CreateFacultyCommandModel model)
        {
            var command = new CreateFacultyCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [Authorize(Role.Admin)]
        [HttpPut("UpdateFaculty")]
        public async Task<IActionResult> UpdateFaculty(UpdateFacultyCommandModel model)
        {
            var command = new UpdateFacultyCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }


        [HttpGet("GetFaculty/{id}")]
        public async Task<IActionResult> GetFaculty(Guid id)
        {
            var query = new GetFacultyQuery(_repositoryProvider, id);

            return Ok(await query.HandleAsync());
        }



        [HttpGet("GetFaculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var query = new GetAllFacultyQuery(_repositoryProvider);

            return Ok(await query.HandleAsync());
        }

    }
}
