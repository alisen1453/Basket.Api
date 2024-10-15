using Basket.Bussiness.Abstract;
using Basket.Core.Abstract;
using Basket.Entities.Entity;
using Basket.Entities.EntityDto;

namespace Basket.Bussiness.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerServices(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async Task AddUser(CustomerDto customerDto)
        {



            var customer = new Customer()
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,

            };

            await _customerRepository.AddAsync(customer);

        }

    }
}
