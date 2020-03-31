using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMvcApi.Models;

namespace MovieMvcApi.Service
{
    public interface IMovieService
    {
        IEnumerable<MovieModel> GetAll();
    }
}