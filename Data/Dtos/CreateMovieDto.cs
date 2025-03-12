using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

public class CreateMovieDto
{
    [Required]
    public required string Title { get; set; }
    [Required, StringLength(50)]
    public required string Genre { get; set; }
    [Required, Range(70, 600)]
    public int Duration { get; set; }
}