using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

/// <summary>
/// Data Transfer Object for reading address.
/// </summary>
public class ReadAddressDto
{
    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets the address streetor avenue.
    /// </summary>
    public required string Street_Avenue { get; set; }
}