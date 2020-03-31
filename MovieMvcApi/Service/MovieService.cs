using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return _context.Movies.ToList();
        }
    }
}