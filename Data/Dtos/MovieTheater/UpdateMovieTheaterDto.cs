namespace MoviesAPI.Data.Dtos.MovieTheater
{
    /// <summary>
    /// Data Transfer Object for update a movie theater.
    /// </summary>
    public class UpdateMovieTheaterDto
    {
        /// <summary>
        /// Gets or sets the movie theater name.
        /// </summary>
        public required string Nome { get; set; }
    }
}
