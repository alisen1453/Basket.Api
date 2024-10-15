using Basket.Entities.EntityDto;

namespace Basket.Bussiness.Abstract
{
    public interface IProductServices
    {
        Task AddProduct(ProductDto productDto);
    }
}
