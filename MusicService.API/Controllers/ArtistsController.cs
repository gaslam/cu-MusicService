using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        MusicServiceContext _context;

        public ArtistsController(MusicServiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var model = await _context.Artists
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Picture = a.ImagePath
                })
                .ToListAsync();
            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var model = await _context.Artists.FindAsync(Guid.Parse(id));

            if (model != null)
            {
                var dto = new ArtistDto { Id = model.Id, Name = model.Name, Picture = model.ImagePath };
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
            var model = await _context.Artists.Include(a => a.Albums).FirstOrDefaultAsync(a => a.Id.ToString() == id);

            if (model != null)
            {
                var dto = new ArtistWithAlbumsDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    Picture = model.ImagePath,
                    Albums = new List<AlbumDto>()
                };

                foreach (var album in model.Albums)
                {
                    dto.Albums.Add(new AlbumDto
                    {
                        Id = album.Id,
                        Name = album.Name
                    });
                }
                return Ok(dto);
            }
            else
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }
        }
    }
}