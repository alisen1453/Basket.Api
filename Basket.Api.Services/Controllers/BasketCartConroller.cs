﻿using Basket.Api.Bussiness.Abstract;
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
                return BadRequest(new { message = "Sepete eklemek için geçerli bir ürün bilgisi sağlanmadı." });
            }

            var response = await _CartServices.AddCartOrGetCart(item, true);

            return Ok(response);

        }

        // Sepetten ürün eksiltme işlemi
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] BasketItemDto item)
        {
            if (item == null)
            {
                return BadRequest(new { message = "Sepetten çıkarmak için geçerli bir ürün bilgisi sağlanmadı." });
            }

            var response = await _CartServices.AddCartOrGetCart(item, false);


            return Ok(response);

        }




    }

    }
