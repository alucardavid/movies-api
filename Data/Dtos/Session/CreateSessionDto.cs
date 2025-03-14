using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Session
{
    /// <summary>
    /// Data Transfer Object for creating a session.
    /// </summary>
    public class CreateSessionDto
    {
        /// <summary>
        /// Gets or sets the movieid.
        /// </summary>
        [Required]
        public required int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie theater identifier.
        /// </summary>
        [Required]
        public int MovieTheaterId { get; set; }
    }
}
