using AutoMapper;
using MoviesAPI.Data.Dtos.User;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
