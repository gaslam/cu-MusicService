﻿using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerCrudBase<Genre, GenreRepository>
    {
        public GenresController(GenreRepository genreRepository) : base(genreRepository)
        {
        }
    }
}