using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        PaymentTypeRouter _router = new();

        [HttpGet("GetAllPaymentTypes")]
        public List<Paymenttype> GetPaymentTypes()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddPaymentType")]
        public bool PostPaymentType(Paymenttype value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditPaymentType")]
        public bool PutPaymentType(Paymenttype value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpDelete("DeletePaymentType")]
        public bool DeletePaymentType(Paymenttype value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
