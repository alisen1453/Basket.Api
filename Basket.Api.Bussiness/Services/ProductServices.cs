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
    public class ProductServices:IProductServices
    { 
       public readonly IRepository<Product> _repository;

        public ProductServices(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task AddProduct(ProductDto productDto)
        {
            var product=new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,

            };
           await _repository.AddAsync(product);


        }
    }
}
