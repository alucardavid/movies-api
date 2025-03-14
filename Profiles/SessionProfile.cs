using AutoMapper;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    /// <summary>
    /// Profile class for mapping Session related DTOs to Session model and vice versa.
    /// </summary>
    public class SessionProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProfile"/> class.
        /// Configures the mappings between Session DTOs and Session model.
        /// </summary>
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>();
        }
    }
}
