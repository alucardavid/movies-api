using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

/// <summary>
/// Profile class for mapping Movie related DTOs to Movie model and vice versa.
/// </summary>
public class MovieProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MovieProfile"/> class.
    /// Configures the mappings between Movie DTOs and Movie model.
    /// </summary>
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(m => m.Sessions, opt => opt.MapFrom(m => m.Sessions));
    }
}