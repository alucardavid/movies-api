using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();

    [HttpPost]
    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
        Console.WriteLine(movie.Title);
        Console.WriteLine(movie.Duration);
    }
}
