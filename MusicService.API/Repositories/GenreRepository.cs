using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicService.API.Repositories
{
    public class GenreRepository
    {
        private readonly MusicServiceContext _musicServiceContext;

        public GenreRepository(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }

        // return a list of genres from database table genre
        public async Task<List<Genre>> ListAsync()
        {
            return await _musicServiceContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(string id)
        {
            return await _musicServiceContext.Genres.FindAsync(Guid.Parse(id));
        }

    }
}
