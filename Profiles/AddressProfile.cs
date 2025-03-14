using AutoMapper;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

/// <summary>
/// Profile class for mapping Address related DTOs to Address model and vice versa.
/// </summary>
public class AddressProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddressProfile"/> class.
    /// Configures the mappings between Address DTOs and Address model.
    /// </summary>
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
        CreateMap<Address, ReadAddressDto>();
    }
}