using MusicService.API.Data;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class GenreRepository : Repository<Genre>, IRepository<Genre>
    {
        public GenreRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}
