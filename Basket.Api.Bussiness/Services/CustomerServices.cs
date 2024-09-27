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
        private readonly IRepository<BasketCart> _basketcartRepository;

        public CustomerServices(IRepository<Customer> customerRepository, IRepository<BasketCart> basketcartRepository)
        {
            _customerRepository = customerRepository;
            _basketcartRepository = basketcartRepository;
        }

        public async  Task AddUser(CustomerDto customerDto ) {



            var customer = new Customer()
            {
                Name = customerDto.Name,
                Email = customerDto.Email
            };

            // Müşteriyi veri tabanına ekle
            await _customerRepository.AddAsync(customer);


            // BasketCart oluştur ve müşteri Id'sini ata
            var basketCart = new BasketCart()
            {
                CustomerId = customer.CostumerId  // Name yerine Id atanır
            };

            // BasketCart'ı veri tabanına ekle
            await _basketcartRepository.AddAsync(basketCart);
           











            //var customer = new Customer()
            //{
            //    Name = customerDto.Name,
            //    Email = customerDto.Email,  


            //};
            //var baskecart = new BasketCart()
            //{
            //    CustomerId=customer.Name

            //};
            //_customerRepository.AddAsync(customer);
            //return Task.CompletedTask;
            ////if (customer == null)
            ////{
            ////    throw new ArgumentNullException(nameof(customer), "Customer data cannot be null.");
            ////}



        }

    }
}
