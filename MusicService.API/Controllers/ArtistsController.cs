using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly MusicServiceContext _musicServiceContext;

        public ArtistsController(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var artists = await _musicServiceContext.Artists.ToListAsync();
            return Ok(artists);
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
            var artist = await _musicServiceContext.Artists.Include(a => a.Albums).SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (artist != null)
            {
                string output = JsonConvert.SerializeObject(artist, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return Ok(output);
            }
            else
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }
        }
    }
}