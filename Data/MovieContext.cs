using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

/// <summary>
/// Context to connect to a database
/// </summary>
public class MovieContext : DbContext
{
    /// <summary>
    /// Constructor to set options to a base class
    /// </summary>
    /// <param name="opts"></param>
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts){}

    /// <summary>
    /// Gets or sets to a entitie Movies
    /// </summary>
    public DbSet<Movie> Movies {get; set;}

    /// <summary>
    /// Gets or sets to a entitie MoviesTheaters
    /// </summary>
    public DbSet<MovieTheater> MovieTheaters {get; set;}

    /// <summary>
    /// Gets or sets to a entitie Addresses
    /// </summary>
    public DbSet<Address> Addresses { get; set; }
}