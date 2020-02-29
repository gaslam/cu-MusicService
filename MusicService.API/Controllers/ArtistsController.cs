using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IRepository<Artist> _artistRepository;

        public ArtistsController(IRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            return Ok(await _artistRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var artist = await _artistRepository.GetById(id);

            if (artist == null)
            {
                return NotFound($"Artist with {id} was not found!");
            }
            return Ok(artist);
        }
    }
}