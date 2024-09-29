using Basket.Api.Bussiness.Abstract;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using Basket.Api.Entities.EntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Bussiness.Services
{
    public class CustomerServices:ICustomerServices
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerServices(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            
        }

        public async  Task AddUser(CustomerDto customerDto ) {



            var customer = new Customer()
            {
                Name = customerDto.Name,
                Email = customerDto.Email
            };

            await _customerRepository.AddAsync(customer);

        }

    }
}
