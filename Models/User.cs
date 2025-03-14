using Microsoft.AspNetCore.Identity;

namespace MoviesAPI.Models;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public User() : base() { }
}
