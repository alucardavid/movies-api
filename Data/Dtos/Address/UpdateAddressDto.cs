using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Address;

/// <summary>
/// Data Transfer Object for update a address.
/// </summary>
public class UpdateAddressDto
{
    /// <summary>
    /// Gets or sets the address streetor avenue.
    /// </summary>
    [Required]
    [StringLength(100), MinLength(5)]
    public required string Street_Avenue { get; set; }

}