using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

/// <summary>
/// Data Transfer Object for update a movie.
/// </summary>
public class UpdateMovieDto
{
    /// <summary>
    /// Gets or sets the movie title.
    /// </summary>
    [Required]
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the movie genre.
    /// </summary>
    [Required, StringLength(50)]
    public required string Genre { get; set; }

    /// <summary>
    /// Gets or sets the movie duration.
    /// </summary>
    [Required, Range(70, 600)]
    public int Duration { get; set; }
}