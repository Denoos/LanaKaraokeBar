using LanaKaraokeBar_DataBaseApi.Controllers.Routers;
using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanaKaraokeBar_DataBaseApi.Controllers.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductRouter _router = new();

        [HttpGet("GetAllProducts")]
        public List<Product> GetProducts()
        {
            return _router.ComposeGetRoute();
        }

        [HttpPost("AddProduct")]
        public bool PostProduct(Product value)
        {
            return _router.ComposePostRoute(value);
        }

        [HttpPut("EditProduct")]
        public bool PutProduct(Product value)
        {
            return _router.ComposePutRoute(value);
        }

        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(Product value)
        {
            return _router.ComposeDeleteRoute(value);
        }
    }
}
