using Basket.Bussiness.Abstract;
using Basket.Core.Abstract;
using Basket.Entities.Entity;
using Basket.Entities.EntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Bussiness.Services
{
    public class ProductServices : IProductServices
    {
        public readonly IRepository<Product> _repository;

        public ProductServices(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task AddProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description

            };
            await _repository.AddAsync(product);


        }
    }
}
