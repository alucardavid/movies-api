using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.User
{
    public class LoginUserDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
