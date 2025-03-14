using MoviesAPI.Data.Dtos.Session;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Movie;

/// <summary>
/// Data Transfer Object for reading movie details.
/// </summary>
public class ReadMovieDto
{

    /// <summary>
    /// Gets or sets the title identifier
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the movie.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the genre of the movie.
    /// </summary>
    public required string Genre { get; set; }

    /// <summary>
    /// Gets or sets the duration of the movie in minutes.
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Gets or sets the time when the query was made.
    /// </summary>
    public DateTime TimeQuery { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets movie sessions.
    /// </summary>
    public required ICollection<ReadSessionDto> Sessions { get; set; }
}