using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.User;

public class CreateUserDto
{
    [Required]
    public required string UserName { get; set; }

    [Required]
    public required DateTime BirthDate { get; set; }

    [Required, DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required, Compare("Password")]
    public required string RePassword { get; set; }
}
