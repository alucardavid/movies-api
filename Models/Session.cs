using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    /// <summary>
    /// Class that represent the movie session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Gets and sets the session identifier
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the movie identifier.
        /// </summary>
        [Required]
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movie associated with the session.
        /// </summary>
        public required virtual Movie Movie { get; set; }

        /// <summary>
        /// Gets or sets the movie theater identifier.
        /// </summary>
        [Required]
        public int MovieTheaterId { get; set; }

        /// <summary>
        /// Gets or sets the movie theater object.
        /// </summary>
        public required virtual MovieTheater MovieTheater { get; set; }


    }
}
