using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        movie.Id = id++;
        movies.Add(movie);
        return CreatedAtAction(nameof(ReadMovieById), new { Id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 50){
        return movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ReadMovieById(int id)
    {
        var movie =  movies.FirstOrDefault(m => m.Id == id);
        if (movie is null) return NotFound();
        return Ok(movie);
    }
}