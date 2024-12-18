using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Interface;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _repo;
        public MovieController(IMovie repo)
        {
            _repo = repo;
        }

        [HttpPost("AddMovie")]
        public IActionResult AddAllMovie(AddAllMovieDto addAllMovieDto)
        {
            _repo.AddAllMovie(addAllMovieDto);
            return Ok();
        }

        [HttpGet("GetAllMovie")]
        public IActionResult GetAllMovie()
        {
            var result = _repo.GetAllMovie();
            return Ok(result);
        }

        [HttpGet("GetMovieById")]
        public IActionResult GetMovieById(int id)
        {
            var result = _repo.GetMovieById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}