using Basket.Bussiness.Abstract;
using Basket.Entities.EntityDto;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Services.Controllers
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



        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] BasketItemDto item)
        {

            //if (item == null)
            //{
            //    return BadRequest("Geçersiz sepet öğesi.");
            //}

            //try
            //{
            //    await _CartServices.AddCartOrGetCart(item, true);
            //    return Ok(new { message = "Item sepete eklendi.", item });
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "Sepet ekleme sırasında hata oluştu.", error = ex.Message });
            //}
            await _CartServices.AddCartOrGetCart(item, true);
            return new OkResult();

        }

        [HttpPost("Remove")]
        public async Task<IActionResult> RemoveCartItem(BasketItemDto item)
        {
            await _CartServices.AddCartOrGetCart(item, false);
            return Ok(item);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(Guid id)
        {
            var items = await _CartServices.GetItemListAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }


    }

}
