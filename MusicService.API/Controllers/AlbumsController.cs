using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumsController(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            return Ok(await _albumRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var album = await _albumRepository.GetById(id);

            if (album == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(album);
        }
    }
}