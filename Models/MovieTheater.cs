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
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the movie addressId.
        /// </summary>
        [Required]
        public required int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the movie address.
        /// </summary>
        public required virtual Address Address { get; set; }
    }
}
