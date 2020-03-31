using System;
using System.ComponentModel.DataAnnotations;

namespace MovieMvcApi.Models
{
    public class MovieModel
    {
        [Key]
        public int ID { get; set; }
        public String Title { get; set; }
        public String Genre { get; set; }
    }
}