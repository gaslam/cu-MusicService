using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerCrudBase<Genre, IRepository<Genre>>
    {
        public GenresController(IRepository<Genre> genreRepository) : base(genreRepository)
        {
        }
    }
}