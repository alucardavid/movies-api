using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        [Required]
        public string Title { get; set; }
        [Required, MaxLength(50)]
        public string Genre { get; set; }
        [Required, Range(70, 600)]
        public int Duration { get; set; }
    }
}
