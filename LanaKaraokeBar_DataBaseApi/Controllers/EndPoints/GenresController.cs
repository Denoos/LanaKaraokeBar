using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        GenreRouter _router = new();

        [HttpGet("GetAllGenres")]
        public List<Genre> GetGenres()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddGenre")]
        public bool PostGenre(Genre value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditGenre")]
        public bool PutGenre(Genre value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpDelete("DeleteGenre")]
        public bool DeleteGenre(Genre value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
