
using Basket.Api.Bussiness.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
         readonly ICustomerServices _services;

        public CostumerController(ICustomerServices customer)
        {
            _services = customer;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDto customers)
        {
           

           await _services.AddUser(customers);
            return Ok(customers);
        }
        
    }
}
