using Basket.Bussiness.Abstract;
using Basket.Core.Abstract;
using Basket.Core.Exceptions;
using Basket.Core.Response;
using Basket.Entities.Entity;
using Basket.Entities.EntityDto;
using Microsoft.EntityFrameworkCore;

namespace Basket.Bussiness.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerServices(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async Task AddUser(CustomerDto item)
        {
            var customerExists = await _customerRepository.Query().Where(c => c.Email == item.Email).FirstOrDefaultAsync();
            if (customerExists != null)
            {
                throw new NotFoundException("Kullanıcı kayıtlıdır.");
            }



            var customer = new Customer()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,

            };

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveorUpdate();

        }

    }
}
