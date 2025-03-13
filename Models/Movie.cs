using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the movie identifier.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the movie title.
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the movie genre.
        /// </summary>
        [Required, MaxLength(50)]
        public required string Genre { get; set; }

        /// <summary>
        /// Gets or sets the movie duration in minutes.
        /// </summary>
        [Required, Range(70, 600)]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the collection of sessions associated with the movie.
        /// </summary>
        public required virtual ICollection<Session> Sessions { get; set; }
    }
}