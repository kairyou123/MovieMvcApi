using System.Collections.Generic;
using MovieMvcApi.Models;

namespace MovieMvcApi.Service
{
    public interface IMovieService
    {
         IEnumerable<MovieModel> GetAll();
    }
}