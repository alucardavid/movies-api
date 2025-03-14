using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoviesAPI.Data.Dtos.User;
using MoviesAPI.Models;

namespace MoviesAPI.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    internal async Task LoginAsync(LoginUserDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        if (!result.Succeeded) throw new ApplicationException("Login fail!");
    }

    internal async Task RegisterAsync(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded) throw new ApplicationException("Fail to create user!");

    }
}
