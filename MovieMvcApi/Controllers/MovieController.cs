using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMvcApi.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace MovieMvcApi.Controllers
{
    public class MovieController : Controller
    {

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();  
            var result = client.GetAsync("http://localhost:5000/api/MovieApi").Result;  
            if (result.IsSuccessStatusCode)  
            {  
                var data  = result.Content.ReadAsStringAsync().Result; 
                var mylist = JsonConvert.DeserializeObject<IEnumerable<MovieModel>>(data);
                return View("~/Views/Movie/Index.cshtml", mylist);
            }  
            return NotFound();
            
        }

    }
}