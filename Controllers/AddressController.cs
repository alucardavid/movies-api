using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

/// <summary>
/// Controller for managing addresses.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates a new address.
    /// </summary>
    /// <param name="addressDto">The address data transfer object.</param>
    /// <returns>The created address.</returns>
    [HttpPost]
    public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadAddressById), new { Id = address.Id }, address);
    }

    /// <summary>
    /// Reads all addresses.
    /// </summary>
    /// <returns>A list of address data transfer objects.</returns>
    [HttpGet]
    public IEnumerable<ReadAddressDto> ReadAddress()
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses);
    }

    /// <summary>
    /// Reads an address by its ID.
    /// </summary>
    /// <param name="id">The address ID.</param>
    /// <returns>The address data transfer object.</returns>
    [HttpGet("{id}")]
    public IActionResult ReadAddressById(int id)
    {
        Address? address = _context.Addresses.FirstOrDefault(endereco => endereco.Id == id);
        if (address != null)
        {
            ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
            return Ok(addressDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Updates an existing address.
    /// </summary>
    /// <param name="id">The address ID.</param>
    /// <param name="addressDto">The address data transfer object.</param>
    /// <returns>No content if the update is successful.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address? address = _context.Addresses.FirstOrDefault(endereco => endereco.Id == id);
        if (address == null) return NotFound();
        
        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deletes an address by its ID.
    /// </summary>
    /// <param name="id">The address ID.</param>
    /// <returns>No content if the deletion is successful.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address? address = _context.Addresses.FirstOrDefault(endereco => endereco.Id == id);
        if (address == null) return NotFound();
        
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}