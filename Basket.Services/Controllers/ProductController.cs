using Basket.Bussiness.Abstract;
using Basket.Entities.EntityDto;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Services.Controllers
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
        public async Task AddProducts(ProductDto productDto)
        {
            await _services.AddProduct(productDto);


        }
    }
}
