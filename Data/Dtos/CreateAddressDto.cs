using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

/// <summary>
/// Data Transfer Object for creating a address.
/// </summary>
public class CreateAddressDto
{
    /// <summary>
    /// Gets or sets the address street or avenue.
    /// </summary>
    [Required]
    [StringLength(100), MinLength(5)]
    public required string Street_Avenue { get; set; }

    /// <summary>
    /// Gets and sets the street number 
    /// </summary>
    [Required]
    public required int Number { get; set; }

    
}