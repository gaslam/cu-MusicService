using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using MusicService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Repositories
{
    public class ArtistRepository
    {
        private readonly MusicServiceContext _musicServiceContext;

        public ArtistRepository(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }

        // return a list of artists from database table artist
        public async Task<List<Artist>> ListAsync()
        {
            return await _musicServiceContext.Artists.ToListAsync();
        }

        // return a list of artists as a list of ArtistDto's
        public async Task<List<ArtistDto>> ListDtoAsync()
        {
            return await _musicServiceContext.Artists.Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Picture = a.ImagePath
            }).ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(string id)
        {
            return await _musicServiceContext.Artists.FindAsync(Guid.Parse(id));
        }

        public async Task<ArtistDto> GetDtoByIdAsync(string id)
        {
            var model = await GetByIdAsync(id);

            if (model == null)
            {
                return null;
            }

            return new ArtistDto
            {
                Id = model.Id,
                Name = model.Name,
                Picture = model.ImagePath
            };
        }

        public async Task<ArtistWithAlbumsDto> GetAlbumsByArtistIdAsync(string id)
        {
            var model = await _musicServiceContext.Artists
                .Include(a => a.Albums)
                .SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (model == null)
            {
                return null;
            }

            var dto = new ArtistWithAlbumsDto
            {
                Id = model.Id,
                Name = model.Name,
                Picture = model.ImagePath,
                Albums = model.Albums.Select(a => new AlbumDto { Id = a.Id, Name = a.Name }).ToList()
            };

            return dto;
        }
    }
}
