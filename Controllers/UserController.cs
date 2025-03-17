using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.Dtos.User;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUserAsync(CreateUserDto userDto)
    {
       await _userService.RegisterAsync(userDto);
        return Ok("User created!");
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto loginDto)
    {
        var token = await _userService.LoginAsync(loginDto);
        return Ok(token);
    }

}
