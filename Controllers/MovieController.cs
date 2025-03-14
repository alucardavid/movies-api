using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using MoviesAPI.Models;
using MoviesAPI.Data.Dtos.Movie;
namespace MoviesAPI.Controllers;

/// <summary>
/// Controller for managing movies.
/// </summary>
[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovieController"/> class.
    /// </summary>
    /// <param name="context">The movie context.</param>
    /// <param name="mapper">The mapper.</param>
    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a new movie to the database.
    /// </summary>
    /// <param name="movieDto">The movie DTO.</param>
    /// <returns>The action result.</returns>
    /// <response code="201">If the movie was created successfully.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieById), new { Id = movie.Id }, movie);
    }

    /// <summary>
    /// Reads the list of movies.
    /// </summary>
    /// <param name="skip">The number of movies to skip.</param>
    /// <param name="take">The number of movies to take.</param>
    /// <returns>The list of movie DTOs.</returns>
    [HttpGet]
    public IEnumerable<ReadMovieDto> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Reads a movie by its ID.
    /// </summary>
    /// <param name="id">The movie ID.</param>
    /// <returns>The action result.</returns>
    [HttpGet("{id}")]
    public IActionResult ReadMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie is null) return NotFound();
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    /// <summary>
    /// Updates a movie by its ID.
    /// </summary>
    /// <param name="id">The movie ID.</param>
    /// <param name="movieDto">The movie DTO.</param>
    /// <returns>The action result.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.Find(id);
        if (movie is null) return NotFound();
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Partially updates a movie by its ID.
    /// </summary>
    /// <param name="id">The movie ID.</param>
    /// <param name="patch">The JSON patch document.</param>
    /// <returns>The action result.</returns>
    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartial(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.Find(id);
        if (movie is null) return NotFound();
        
        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate)) return ValidationProblem(ModelState);

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deletes a movie by its ID.
    /// </summary>
    /// <param name="id">The movie ID.</param>
    /// <returns>The action result.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie is null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}