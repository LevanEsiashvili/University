using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.SubjectModels;
using University.Command.Commands.SubjectCommands;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Query.Queries.StudentSubjectQueries;
using University.Query.Queries.SubjectQueris;
using University.Shared.Enumes;
using University.WebApi.Service;

namespace University.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route(nameof(SubjectController))]
    public class SubjectController : BaseController
    {
        public SubjectController(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService) : base(repositoryProvider,authorizedUserService)
        {
        }

        [Authorize(Role.Admin)]
        [HttpPost("create-subject")]
        public async Task<IActionResult> CreateSubject(CreateSubjectCommandModel model)
        {

            var command = new CreateSubjectComand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [Authorize(Role.Admin)]
        [HttpPut("updateSubject")]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectCommandModel model)
        {
            var command = new UpdateSubjectcCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());

        }

        [Authorize(Role.Admin)]
        [HttpPost("RegissterLecturersOnSubject")]
        public async Task<IActionResult> RegissterLecturersOnSubject(RegissterLecturersOnSubjectCommandModel model)
        {
            var command = new RegissterLecturersOnSubjectCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [Authorize(Role.Admin)]
        [HttpDelete("DeleteLecturerInSubject")]
        public async Task<IActionResult> DeleteLecturerInSubject(DeleteLecturersOnSubjectCommandModel model)
        {
            var command = new DeleteLecturerInSubject(_repositoryProvider, model);
            return Ok(await command.HandleAsync());

        }

        
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            var query = new GetAllSubjectQuery(_repositoryProvider);

            return Ok(await query.HandleAsync());

        }

        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject(Guid id)
        {
            var query = new GetSubjectQuery(_repositoryProvider, id);

            return Ok(await query.HandleAsync());

        }

        [Authorize(Role.Admin,Role.Lecturer)]
        [HttpGet ("GetAllSubjectWithLecturers")]
        public async Task<IActionResult> GetAllSubjectWithLecturers()
        {
            var query = new GetAllSubjectWithLecturersQuery(_repositoryProvider);

            return Ok(await query.HandleAsync());
        }

        [Authorize(Role.Admin, Role.Lecturer)]
        [HttpGet("GetSubjectWithLecturers/{id}")]
        public async Task<IActionResult> GetSubjectWithLecturers(Guid id)
        {
            var query = new GetSubjectWithLecturersQuery(_repositoryProvider, id );

            return Ok(await query.HandleAsync());
        }


        [Authorize(Role.Lecturer)]
        [HttpGet("GetSubjectWithStudent/{subjectId}")]

        public async Task<IActionResult> GetSubjectWithStudent(Guid subjectId)
        {
            var query = new GetSubjectWithStudentsQuery(_repositoryProvider, _authorizedUserService, subjectId);

            return Ok(await query.HandleAsync());
        }

        [HttpGet("GetSubjectWithExams/{subjectId}")]

        public async Task<IActionResult> GetSubjectWithExams(Guid subjectId)
        {
            var query = new GetSubjectWithExamsQuery(_repositoryProvider,_authorizedUserService, subjectId);
            return Ok(await query.HandleAsync());
        }


    }
}
