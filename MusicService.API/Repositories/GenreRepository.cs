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
        private readonly MusicServiceContext db;

        public GenreRepository(MusicServiceContext context)
        {
            db = context;
        }

        // return a list of genres from database table genre
        public async Task<List<Genre>> ListAsync()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(string id)
        {
            return await db.Genres.FindAsync(Guid.Parse(id));
        }

    }
}
