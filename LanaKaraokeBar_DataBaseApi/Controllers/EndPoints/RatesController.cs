using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        RateRouter _router = new();

        [HttpGet("GetAllRates")]
        public List<Rate> GetRates()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddRate")]
        public bool PostRate(Rate value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditRate")]
        public bool PutRate(Rate value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpDelete("DeleteRate")]
        public bool DeleteRate(Rate value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
