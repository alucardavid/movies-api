using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    /// <summary>
    /// Controller for managing sessions.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SessionController : Controller
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionController"/> class.
        /// </summary>
        /// <param name="context">The movie context.</param>
        /// <param name="mapper">The mapper.</param>
        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="dto">The session data transfer object.</param>
        /// <returns>A newly created session.</returns>
        [HttpPost]
        public IActionResult CreateSession(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadSessionById), new { movieId = session.Id }, session);
        }

        /// <summary>
        /// Gets all sessions.
        /// </summary>
        /// <returns>A list of sessions.</returns>
        [HttpGet]
        public IEnumerable<ReadSessionDto> ReadSessions()
        {
            return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
        }

        /// <summary>
        /// Gets a session by movieId and movieTheaterId.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="movieTheaterId"></param>
        /// <returns>The session with the specified identifier.</returns>
        [HttpGet("{movieId}/{movieTheaterId}")]
        public IActionResult ReadSessionById(int movieId, int movieTheaterId)
        {
            Session? session = _context.Sessions.FirstOrDefault(s => s.MovieId == movieId && s.MovieTheaterId == movieTheaterId);
            if (session != null)
            {
                ReadSessionDto sessaoDto = _mapper.Map<ReadSessionDto>(session);
                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}