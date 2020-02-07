using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using System;
using System.Linq;
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
            var artists = await _musicServiceContext.Artists
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Picture = a.ImagePath
                })
                .ToListAsync();
            return Ok(artists);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var artist = await _musicServiceContext.Artists.FindAsync(Guid.Parse(id));

            if (artist != null)
            {
                var dto = new ArtistDto { Id = artist.Id, Name = artist.Name, Picture = artist.ImagePath };
                return Ok(dto);
            }
            else
            {
                return NotFound($"Artist with {id} was not found!");
            }
        }


        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string id)
        {
            var artistWithAlbums = await _musicServiceContext.Artists.Include(a => a.Albums).SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (artistWithAlbums != null)
            {
                var dto = new ArtistWithAlbumsDto
                {
                    Id = artistWithAlbums.Id,
                    Name = artistWithAlbums.Name,
                    Picture = artistWithAlbums.ImagePath,
                    Albums = artistWithAlbums.Albums.Select(a => new AlbumDto { Id = a.Id, Name = a.Name }).ToList()
                };

                return Ok(dto);
            }
            else
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }
        }
    }
}