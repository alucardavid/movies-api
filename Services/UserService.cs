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
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    internal async Task<string> LoginAsync(LoginUserDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        if (!result.Succeeded) throw new ApplicationException("Login fail!");

        User? user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == loginDto.Username.ToUpper());
        
        var token = _tokenService.GenerateToken(user);

        return token;
    }

    internal async Task RegisterAsync(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded) throw new ApplicationException("Fail to create user!");

    }
}
