using MusicService.API.Data;
using MusicService.API.Repositories.Base;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class TrackRepository : Repository<Track>
    {
        public TrackRepository(MusicServiceContext context) : base(context)
        {

        }
    }
}
