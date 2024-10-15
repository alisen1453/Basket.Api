using Basket.Bussiness.Abstract;
using Basket.Core.Abstract;
using Basket.Core.Response;
using Basket.Entities.Entity;
using Basket.Entities.EntityDto;
using Microsoft.EntityFrameworkCore;

namespace Basket.Bussiness.Services
{
    public class BasketCartServices : IBasketCartServices
    {
        private readonly IRepository<Cart> _cartrepository;
        private readonly IRepository<Customer> _customerrepository;
        private readonly IRepository<CartItem> _Itemrepository;
        private readonly IRepository<Product> _productrepository;

        public BasketCartServices(IRepository<Cart> cartrepository, IRepository<Customer> customerrepository,
            IRepository<CartItem> ıtemrepository, IRepository<Product> productrepository)
        {
            _cartrepository = cartrepository;
            _customerrepository = customerrepository;
            _Itemrepository = ıtemrepository;
            _productrepository = productrepository;
        }

        public async Task AddCartOrGetCart(BasketItemDto item, bool entry = true)
        {
            // Müşterinin var olup olmadığını kontrol et
            //  var customerExists = await _customerrepository.Query().AnyAsync(c => c.CustomerId == item.CustomerId);



            // Mevcut sepeti bul veya yeni bir sepet oluştur
            var entity = await _cartrepository.Query()
                .Include(x => x.CartItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.CustomerId == item.CustomerId);
            if (entity == null)
            {

                entity = new Cart { CustomerId = item.CustomerId };
                await _cartrepository.AddAsync(entity);

            }


            var product = await _productrepository.Query().AsTracking().
                FirstOrDefaultAsync(x => x.ProductId == item.ProductId);//Stok kontrolu.


            if (product != null)
            {

                var cartitem = entity.CartItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (cartitem == null)
                {
                    //product sorgulama


                    //CartItem ürün ekeleme.
                    if (product.Stock <= item.Quantity) { throw new NotFoundException("Stok yetersiz"); }
                    else
                    {
                        entity.CartItems.Add(new CartItem
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            CartId = entity.CartId,
                            UpdateTime = DateTime.UtcNow.AddHours(3),

                        });
                        await _cartrepository.UpdateAsync(entity);

                        product.Stock -= item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }

                }
                else
                {

                    if (entry)
                    {
                        if (product.Stock <= item.Quantity) { throw new NotFoundException("Stok yetersiz"); }
                        else
                        {

                            cartitem.Quantity += item.Quantity;
                            await _cartrepository.UpdateAsync(entity);
                            product.Stock -= item.Quantity;
                            await _productrepository.UpdateAsync(product);
                        }
                    }
                    else
                    {
                        cartitem.Quantity -= item.Quantity;
                        await _cartrepository.UpdateAsync(entity);
                        product.Stock += item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }
                }

            }

        }

        public async Task<object> GetItemListAsync(Guid id)
        {
            try
            {
                var cart = await _cartrepository.Query()
                    .Include(x => x.CartItems)
                    .ThenInclude(y => y.Product)
                    .Where(x => x.CustomerId == id)
                    .Select(x => new
                    {
                       
                     
                        CartItems = x.CartItems.Select(ci => new
                        {
                            ProductName = ci.Product.Name,
                            ProductPrice = ci.Product.Price,
                            UpdateTimes=ci.UpdateTime,
                            ProductTotal = ci.Quantity * ci.Product.Price

                        }).ToList(),
                    })
                    .FirstOrDefaultAsync();

                if (cart == null)
                {
                    throw new NotFoundException("Liste Bulunamadı");
                }

                return cart;
            }
            catch (Exception ex)
            {
                throw new Exception($"Sepet öğeleri alınırken bir hata oluştu..: {ex.Message}", ex);
            }
        }


    }
}