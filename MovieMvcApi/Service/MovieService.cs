using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcApi.Data;
using MovieMvcApi.Models;

namespace MovieMvcApi.Service
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context; 
        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieModel> GetAll() 
        { 
           var movies = _context.Movies.ToList();
           return movies;
        }
    }
}