using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Interface;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinema _repo;
        public CinemaController(ICinema repo)
        {
            _repo = repo;
        }

        [HttpPost("AddAllCinema")]
        public IActionResult AddAllCinema(AddAllCinemaDto addAllCinemaDto)
        {
            _repo.AddAllCinema(addAllCinemaDto);
            return Ok();
        }

        [HttpGet("GetAllCinema")]
        public IActionResult GetAllCinema()
        {
            var result = _repo.GetAllCinema();
            return Ok(result);
        }

        [HttpPut("UpdateCinema")]
        public IActionResult UpdateCinema(int id, AddAllCinemaDto addAllCinemaDto)
        {
            _repo.UpdateCinema(id, addAllCinemaDto);
            return Ok();
        }
    }
}