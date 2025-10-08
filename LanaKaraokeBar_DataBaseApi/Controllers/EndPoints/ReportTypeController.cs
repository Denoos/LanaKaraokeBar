using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : ControllerBase
    {
        ReportTypeRouter _router = new();

        [HttpGet("GetAllReportTypes")]
        public List<Reporttype> GetReportTypes()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddReportType")]
        public bool PostReportType(Reporttype value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditReportType")]
        public bool PutReportType(Reporttype value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpDelete("DeleteReportType")]
        public bool DeleteReportType(Reporttype value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
