using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.StudentSubjectExamCommandModels;
using University.Command.Commands.StudentSubjectExamCommands;
using University.Domain.Contracts;
using University.Infrastructure;
using University.Shared.Enumes;
using University.WebApi.Service;

namespace University.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route(nameof(StudentSubjectExamController))]
    public class StudentSubjectExamController : BaseController
    {
        public StudentSubjectExamController(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService) 
            : base(repositoryProvider, authorizedUserService)
        {
        }
       
        [Authorize(Role.Lecturer)]
        [HttpPost("student-assessment")]
        public async Task<IActionResult> StudentAssessment(StudentAssessmentCommandModel model)
        {
            var command = new StudentAssessmentCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok(await command.HandleAsync());
        }

    }
}
