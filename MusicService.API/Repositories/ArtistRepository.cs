using MusicService.API.Data;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}
