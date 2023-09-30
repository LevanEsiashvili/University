using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.ChooseSubjectModels;
using University.Domain.Contracts;
using University.Infrastructure;
using University.WebApi.Service;
using University.Command.Commands.ChooseSubjectCommands;
using University.Query.Queries.StudentSubjectQueries;
using University.Shared.Enumes;
using University.Query.Queries.SubjectProgramQueries;

namespace University.WebApi.Controllers
{
    [Authorize(Role.Student, Role.Admin)]
    [ApiController]
    [Route(nameof(StudentSubjectController))]
    public class StudentSubjectController : BaseController
    {
        
        public StudentSubjectController(RepositoryProvider repositoryProvider,
            IAuthorizedUserService authorizedUserService) : base(repositoryProvider, authorizedUserService)
        {  
            
        }

        [Authorize(Role.Student)]
        [HttpPost("choose-subject")]
        public async Task<IActionResult> ChooseSubject(ChooseSubjectModel model)
        {
            var command = new ChooseSubjectCommand(_repositoryProvider, _authorizedUserService, model);

            return Ok( await command.HandleAsync());
        }

       [HttpGet("GetAllStudentSubject")]

       public async Task<IActionResult> GetAllStudentSubject()
       {
            var query =  new GetAllStudentSubjectsQuery(_repositoryProvider, _authorizedUserService);

            return Ok(await query.HandleAsync());
       }


        [HttpGet("GetStudentSubject")]

        public async Task<IActionResult> GetStudentSubject(Guid subjectId)
        {
            var query = new GetStudentSubjectQuery(_repositoryProvider,_authorizedUserService, subjectId);

            return Ok(await query.HandleAsync());   
        }



    }
}
