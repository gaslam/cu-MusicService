using Microsoft.AspNetCore.Mvc;
using MusicService.API.Controllers.Base;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerCrudBase<Track, IRepository<Track>>
    {
        public TracksController(IRepository<Track> trackRepository) : base(trackRepository)
        {

        }
    }
}