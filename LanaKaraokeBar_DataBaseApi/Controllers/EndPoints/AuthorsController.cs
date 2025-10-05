using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorRouter _router = new();

        [HttpGet("GetAllAuthors")]
        public List<Author> GetAuthors()
        {
            return _router.ComposeGetAuthorRoute();
        }

        [HttpPost("AddAuthor")]
        public bool PostAuthor(Author value)
        {
            return _router.ComposePostAuthorRoute(value);
        }

        [HttpPut("EditAuthor")]
        public bool PutAuthor(Author value)
        {
            return _router.ComposePutAuthorRoute(value);
        }

        [HttpDelete("DeleteAuthor")]
        public bool DeleteAuthor(Author value)
        {
            return _router.ComposeDeleteAuthorRoute(value);
        }
    }
}
