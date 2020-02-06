using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerCrudBase<Track, TrackRepository>
    {
        public TracksController(TrackRepository trackRepository) : base(trackRepository)
        {

        }
    }
}