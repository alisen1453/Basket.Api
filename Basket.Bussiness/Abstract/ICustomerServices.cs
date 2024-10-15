using Basket.Entities.EntityDto;

namespace Basket.Bussiness.Abstract
{
    public interface ICustomerServices
    {
        Task AddUser(CustomerDto customerDto);
    }
}
