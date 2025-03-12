using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    /// <summary>
    /// Controller for managing movie theaters.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController : Controller
    {
        private MovieContext _context;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieTheaterController"/> class.
        /// </summary>
        /// <param name="context">The movie context.</param>
        /// <param name="mapper">The mapper.</param>
        public MovieTheaterController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new movie theater.
        /// </summary>
        /// <param name="movieTheaterDto">The movie theater data transfer object.</param>
        /// <returns>A newly created movie theater.</returns>
        [HttpPost]
        public IActionResult CreateMovieTheater([FromBody] CreateMovieTheaterDto movieTheaterDto)
        {
            MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadMovieTheaterById), new { Id = movieTheater.Id }, movieTheaterDto);
        }

        /// <summary>
        /// Gets all movie theaters.
        /// </summary>
        /// <returns>A list of movie theaters.</returns>
        [HttpGet]
        public IEnumerable<ReadMovieTheaterDto> ReadMovieTheaters()
        {
            return _mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList());
        }

        /// <summary>
        /// Gets a movie theater by its identifier.
        /// </summary>
        /// <param name="id">The movie theater identifier.</param>
        /// <returns>The movie theater with the specified identifier.</returns>
        [HttpGet("{id}")]
        public IActionResult ReadMovieTheaterById(int id)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(cinema => cinema.Id == id);
            if (movieTheater != null)
            {
                ReadMovieTheaterDto cinemaDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        /// <summary>
        /// Updates a movie theater.
        /// </summary>
        /// <param name="id">The movie theater identifier.</param>
        /// <param name="updateMovieTheaterDto">The movie theater data transfer object.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto updateMovieTheaterDto)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(cinema => cinema.Id == id);
            if (movieTheater == null)
            {
                return NotFound();
            }
            _mapper.Map(updateMovieTheaterDto, movieTheater);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletes a movie theater.
        /// </summary>
        /// <param name="id">The movie theater identifier.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {
            MovieTheater? movieTheater = _context.MovieTheaters.FirstOrDefault(cinema => cinema.Id == id);
            if (movieTheater == null)
            {
                return NotFound();
            }
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
