using Basket.Api.Bussiness.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketCartConroller : ControllerBase
    {
        public readonly IBasketCartServices _CartServices;

        public BasketCartConroller(IBasketCartServices ıBasketCartServices)
        {
            _CartServices = ıBasketCartServices;
        }
        [HttpPost]
        [Route("api/cart/add")]
        public async Task<IActionResult> AddCartItem([FromBody] BasketItemDto item)
        {
            if (item == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            var result = await _CartServices.AddCartOrGetCart(item);

            if (!result)
            {
                return StatusCode(500, "Sepete ekleme işlemi başarısız oldu.");
            }

            return Ok("Sepete başarıyla eklendi.");
        }
    }
}
