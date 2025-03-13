using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

/// <summary>
/// Profile class for mapping MovieTheater related DTOs to MovieTheater model and vice versa.
/// </summary>
public class MovieTheaterProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovieTheaterProfile"/> class.
    /// Configures the mappings between MovieTheater DTOs and MovieTheater model.
    /// </summary>
    public MovieTheaterProfile()
    {
        CreateMap<CreateMovieTheaterDto, MovieTheater>();
        CreateMap<UpdateMovieTheaterDto, MovieTheater>();
        CreateMap<MovieTheater, ReadMovieTheaterDto>()
            .ForMember(m => m.Address, opt => opt.MapFrom(m => m.Address))
            .ForMember(m => m.Sessions, opt => opt.MapFrom(m => m.Sessions));

    }
}