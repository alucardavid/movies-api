using MoviesAPI.Models;

namespace MoviesAPI.Data.Dtos.Session
{
    /// <summary>
    /// Data Transfer Object for reading session.
    /// </summary>
    public class ReadSessionDto
    {
        /// <summary>
        /// Gets or sets the MovieId.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the MovieTheaterId.
        /// </summary>
        public int MovieTheaterId { get; set; }


    }
}
