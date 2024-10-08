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



        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] BasketItemDto item)
        {
            
            if (item == null)
            {
                return BadRequest("Geçersiz sepet öğesi.");
            }

            try
            {
                await _CartServices.AddCartOrGetCart(item, true);
                return Ok(new { message = "Item sepete eklendi.", item });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Sepet ekleme sırasında hata oluştu.", error = ex.Message });
            }
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> RemoveCartItem(BasketItemDto item)
        {
            await _CartServices.AddCartOrGetCart(item, false);
            return Ok(item);
            
        }


        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //  var entity=  await _CartServices.GetItemListAsync() ;

        //    return Ok(entity);
        //}


    }

    }
