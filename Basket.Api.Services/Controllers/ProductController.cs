using Basket.Api.Bussiness.Abstract;
using Basket.Api.Entities.EntityDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task AddProducts(ProductDto productDto )
        {
            await _services.AddProduct(productDto);
           
        }
    }
}
