using Microsoft.AspNetCore.Mvc;
using University.Command.CommandModels.ExamModels;
using University.Command.CommandModels.FacultyModels;
using University.Command.Commands.ExamCommands;
using University.Command.Commands.FacultyCommands;
using University.Infrastructure;
using University.Query.Queries.ExamQuries;
using University.Query.Queries.SubjectQueris;
using University.Query.ViewModels.ExamViewModels;

namespace University.WebApi.Controllers
{
    [ApiController]
    [Route(nameof(ExamController))]
    public class ExamController : BaseController
    {
        public ExamController(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }

        [HttpPost("CreateExam")]
        public async Task<IActionResult> CreateExam(CreateExamModel model)
        {
            var command = new CreateExamCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [HttpPut("UpdateExam")]
        public async Task<IActionResult> UpdateExam(UpdateExamModel model)
        {
            var command = new UpdateExamCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [HttpDelete("DeleteExam")]
        public async Task<IActionResult> DeleteExam(DeleteExamModel model)
        {
            var command = new DeleteExamCommand(_repositoryProvider, model);

            return Ok(await command.HandleAsync());
        }

        [HttpGet("Getexam")]
        public async Task<IActionResult> Getexam(Guid Id)
        {
            var Query = new GetexamQuery(_repositoryProvider, Id);

            return Ok(await Query.HandleAsync());
        }

        [HttpGet("Getexams")]
        public async Task<IActionResult> Getexams(Guid subjectId)
        {
            var query = new GetexamsQuery(_repositoryProvider, subjectId);

            return Ok(await query.HandleAsync());
        }


    }
}
