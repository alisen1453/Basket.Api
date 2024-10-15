using Basket.Entities.EntityDto;

namespace Basket.Bussiness.Abstract
{
    public interface IBasketCartServices
    {
        Task AddCartOrGetCart(BasketItemDto item, bool entry = true);
        Task<object> GetItemListAsync(Guid id);
    }
}
