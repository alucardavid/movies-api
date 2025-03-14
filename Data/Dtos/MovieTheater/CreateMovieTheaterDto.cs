using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheater
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

        /// <summary>
        /// Gets or sets the movie theater addressId.
        /// </summary>
        [Required]
        public required int AddressId { get; set; }
    }
}
