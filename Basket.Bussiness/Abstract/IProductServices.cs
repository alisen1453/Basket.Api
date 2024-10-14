using Basket.Entities.EntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Bussiness.Abstract
{
    public interface IProductServices
    {
        Task AddProduct(ProductDto productDto);
    }
}
