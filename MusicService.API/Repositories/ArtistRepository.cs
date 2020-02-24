using MusicService.API.Data;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class ArtistRepository : Repository<Artist>, IRepository<Artist>
    {
        public ArtistRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}
