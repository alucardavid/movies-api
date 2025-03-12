﻿using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using AutoMapper;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieById), new { Id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> ReadMovies([FromQuery] int skip = 0, [FromQuery] int take = 50){
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ReadMovieById(int id)
    {
        var movie =  _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie is null) return NotFound();
        return Ok(movie);
    }
}