using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMvcApi.Models;

namespace MovieMvcApi.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _http;

        public MovieController(IHttpClientFactory http)
        {
            _http = http;
        }

        public IActionResult  Index()
        {
            List<MovieModel> movies= new List<MovieModel>();  
            HttpClient client = new HttpClient();  
            var result = client.GetAsync("http://localhost:5000/api/MovieApi").Result;  
            if (result.IsSuccessStatusCode)  
            {  
                movies = result.Content.ReadAsAsync<List<MovieModel>>().Result; 
                return View("~/Views/Movie/Index.cshtml", movies);
            }  
            return NotFound();
            
        }

    }
}