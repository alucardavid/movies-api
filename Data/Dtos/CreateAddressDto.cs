using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

/// <summary>
/// Data Transfer Object for creating a address.
/// </summary>
public class CreateAddressDto
{
    /// <summary>
    /// Gets or sets the address streetor avenue.
    /// </summary>
    [Required]
    [StringLength(100), MinLength(5)]
    public required string Street_Avenue { get; set; }

    
}