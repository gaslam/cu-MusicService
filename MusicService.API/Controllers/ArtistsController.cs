using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        MusicServiceContext _musicServiceContext;

        public ArtistsController(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var artist = await _musicServiceContext.Artists.ToListAsync();
            return Ok(artist);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var artist = await _musicServiceContext.Artists.FindAsync(Guid.Parse(id));

            if (artist != null)
            {
                return Ok(artist);
            }
            else
            {
                return NotFound($"Artist with {id} was not found!");
            }
        }


        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string id)
        {
            var artist = await _musicServiceContext.Albums.Include(a => a.Artist).Where(a => a.Artist.Id.ToString() == id).ToListAsync();

            if (artist != null)
            {
                return Ok(artist);
            }
            else
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }
        }
    }
}