using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
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
            return CreatedAtAction(nameof(ReadSessionById), new { Id = session.Id }, session);
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
        /// Gets a session by its identifier.
        /// </summary>
        /// <param name="id">The session identifier.</param>
        /// <returns>The session with the specified identifier.</returns>
        [HttpGet("{id}")]
        public IActionResult ReadSessionById(int id)
        {
            Session? session = _context.Sessions.Find(id);
            if (session != null)
            {
                ReadSessionDto sessaoDto = _mapper.Map<ReadSessionDto>(session);
                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}