using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

public class ReadMovieDto
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime TimeQuery { get; set; } = DateTime.Now;
}