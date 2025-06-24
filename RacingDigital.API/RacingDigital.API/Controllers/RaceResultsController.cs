using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RacingDigital.API.Services;

namespace RacingDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultsController : ControllerBase
    {
        private readonly RaceService _service;

        public RaceResultsController(RaceService service)
        {
            _service = service;
        }

        public record NoteRequest(string Note);

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPost("{id}/note")]
        public IActionResult UpdateNote(int id, [FromBody] NoteRequest request)
        {
            _service.UpdateNote(id, request.Note);
            return NoContent();
        }

        [HttpGet("horse/{name}/best-jockey")]
        public IActionResult GetBestJockey(string name)
        {
            var jockey = _service.GetBestJockey(name);
            return jockey == null ? NotFound("No data for this horse") : Ok(jockey);
        }

    }
}
