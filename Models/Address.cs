using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

/// <summary>
/// Class that represent the movie theater address
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the address identifier 
    /// </summary>
    [Key]
    [Required]
    public required int Id { get; set; }

    /// <summary>
    /// Gets and sets the street or avenue 
    /// </summary>
    [Required]
    [MaxLength(100), MinLength(5)]
    public required string Street_Avenue { get; set; }

    /// <summary>
    /// Gets and sets the street number 
    /// </summary>
    [Required]
    public required int Number { get; set; }

    /// <summary>
    /// Gets and sets the object movietheater 
    /// </summary>
    public virtual MovieTheater? MovieTheater { get; set; }

}