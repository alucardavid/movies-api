using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Address;

/// <summary>
/// Data Transfer Object for reading address.
/// </summary>
public class ReadAddressDto
{
    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the address streetor avenue.
    /// </summary>
    public required string Street_Avenue { get; set; }

    /// <summary>
    /// Gets or sets the address street number.
    /// </summary>
    public int Number { get; set; }
}