using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using University.Command.CommandModels.SubjectProgramModels;
using University.Command.Commands.SubjectProgramCommand;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Query.Queries.SubjectProgramQueries;
using University.Shared.Enumes;
using University.WebApi.Service;

namespace University.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route(nameof(SubjectProgramController))]
    public class SubjectProgramController : BaseController
    {

        public SubjectProgramController(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService) : base(repositoryProvider, authorizedUserService)
        {
            
        }

        [Authorize(Role.Lecturer)]
        [HttpPost("CreateSubjectProgram")]
        public async Task<IActionResult> CreateSubjectProgram(CreateSubjectProgramModel model)
        {
            var command = new CreateSubjectProgramCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());
        }

        [Authorize(Role.Lecturer)]
        [HttpPost("UpdateSubjectProgram")]
        public async Task<IActionResult> UpdateSubjectProgram(UpdateSubjectProgramModel model)
        {

            var command = new UpdateSubjectProgramCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());


        }

        [Authorize(Role.Lecturer)]
        [HttpDelete("DeleteSubjectProgram")]
        public async Task<IActionResult> UpdateSubjectProgram(DeleteSubjectProgramModel model)
        {

            var command = new DeleteSubjectProgramCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());


        }

        [HttpGet("GetAllSubjectProgram")]
        public async Task<IActionResult> GetAllSubjectProgram()
        {
            var query = new GetAllSubjectProgramQuery(_repositoryProvider);

            return Ok(await query.HandleAsync());
        }


        [HttpGet("GetSubjectProgram")]
        public async Task<IActionResult> GetSubjectProgram(Guid id)
        {
            var query = new GetSubjectProgramQuery(_repositoryProvider, id );

            return Ok(await query.HandleAsync());
        }

    }
}
