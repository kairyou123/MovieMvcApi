using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMvcApi.Models;
using MovieMvcApi.Service;

namespace MovieMvcApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MovieApiController : ControllerBase
    {
        protected readonly IMovieService _movieService;

        public MovieApiController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetAll());
        }
    }
}