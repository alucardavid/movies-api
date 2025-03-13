namespace MoviesAPI.Data.Dtos
{
    /// <summary>
    /// Data Transfer Object for reading a movie theater.
    /// </summary>
    public class ReadMovieTheaterDto
    {
        /// <summary>
        /// Gets or sets the movie theater id.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the movie theater name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the movie theater address.
        /// </summary>
        public required ReadAddressDto Address { get; set; }

        /// <summary>
        /// Gets or sets the movie theater sessions.
        /// </summary>
        public required ICollection<ReadSessionDto> Sessions { get; set; }
    }
}
