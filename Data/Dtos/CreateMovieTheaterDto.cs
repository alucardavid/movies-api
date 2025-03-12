using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    /// <summary>
    /// Data Transfer Object for creating a movie theater.
    /// </summary>
    public class CreateMovieTheaterDto
    {
        /// <summary>
        /// Gets or sets the movie theater name.
        /// </summary>
        [Required]
        public required string Name { get; set; }
    }
}
