using Microsoft.EntityFrameworkCore;
using MovieMvcApi.Models;

namespace MovieMvcApi.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}