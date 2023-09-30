using Microsoft.AspNetCore.Mvc;
using University.Infrastructure;
using University.Query.Queries.LecturersQueries;

namespace University.WebApi.Controllers
{
    [ApiController]
    [Route(nameof(ExamController))]
    public class LecturerController : BaseController
    {
        public LecturerController(RepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }


        [HttpGet("GetLecturerWhithSubject/{lecturerId}")]

        public async Task<IActionResult> GetLecturerWhithSubject(Guid lecturerId)
        {
            var query = new GetLecturerWhithSubjectQuery(_repositoryProvider, lecturerId);

            return Ok(await query.HandleAsync());
        }

        [HttpGet("GetAllLecturerWhithSubject")]
       
        public async Task<IActionResult> GetAllLecturerWhithSubject()
        {
            var query = new GetAllLecturerWhithSubjectQuery(_repositoryProvider);
            
            return Ok(await query.HandleAsync());
        }

    }
}
