using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MoviesAPI.Models;

namespace MoviesAPI.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new Claim("username", user.UserName!),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        ];

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0fasdasdasdasdadadasdasdsadassasdasdsadasdsadasdsad"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );
            
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}