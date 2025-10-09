using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserRouter _router = new();

        [HttpGet("GetAllUsers")]
        public List<User> GetUser()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddUser")]
        public bool PostUser(User value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditUser")]
        public bool PutUser(User value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpPut("BlockUser")]
        public bool BlockUser(User value)
        {
            return _router.ComposeBlockRoute(value);
        }

        [HttpPut("UnBlockUser")]
        public bool UnBlockUser(User value)
        {
            return _router.ComposeUnBlockRoute(value);
        }

        [HttpDelete("DeleteUser")]
        public bool DeleteUser(User value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
