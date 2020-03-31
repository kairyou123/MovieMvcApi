using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieMvcApi.Data;
using MovieMvcApi.Models;
using MovieMvcApi.Service;

namespace MovieMvcApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IMovieService, MovieService>();
            services.AddDbContext<MovieContext> (options => options.UseSqlite("Data Source=Movies.db"));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Seed(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void Seed(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<MovieContext>();
                if(!context.Movies.Any())
                {

                    var movies = new MovieModel[] 
                    { 
                        new MovieModel { Title = "Good for you", Genre = "Romance"},
                        new MovieModel { Title = "Good for me", Genre = "Romance Comedy"},
                    };

                    foreach(MovieModel movie in movies)
                    {
                        context.Movies.Add(movie);
                    }

                    context.SaveChanges();
                }

                
            }
        }
    }
}
