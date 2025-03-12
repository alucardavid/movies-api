using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    /// <summary>
    /// Represents a movie Theater.
    /// </summary>
    public class MovieTheater
    {
        /// <summary>
        /// Gets or sets the movie theater identifier.
        /// </summary>
        [Key]
        [Required]
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the movie theater name.
        /// </summary>
        [Required]
        public required string Nome { get; set; }
    }
}
