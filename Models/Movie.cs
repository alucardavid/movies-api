﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required, MaxLength(50)]
        public required string Genre { get; set; }
        [Required, Range(70, 600)]
        public int Duration { get; set; }
    }
}
