using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        StatusRouter _router = new();

        [HttpGet("GetAllStatuses")]
        public List<Status> GetStatuses()
        {
            return _router.ComposeGetStatusRoute();
        }

        [HttpPost("AddStatus")]
        public bool PostStatus(Status value)
        {
            return _router.ComposePostStatusRoute(value);
        }

        [HttpPut("EditStatus")]
        public bool PutStatus(Status value)
        {
            return _router.ComposePutStatusRoute(value);
        }

        [HttpDelete("DeleteStatus")]
        public bool DeleteStatus(Status value)
        {
            return _router.ComposeDeleteStatusRoute(value);
        }
    }
}
