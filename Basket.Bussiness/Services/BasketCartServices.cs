using Basket.Access.Context;
using Basket.Bussiness.Abstract;
using Basket.Core.Abstract;
using Basket.Core.Exceptions;
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
        private readonly BasketDbContext _context;

        public BasketCartServices(IRepository<Cart> cartrepository, IRepository<Customer> customerrepository,
            IRepository<CartItem> ıtemrepository, IRepository<Product> productrepository, BasketDbContext context)
        {
            _cartrepository = cartrepository;
            _customerrepository = customerrepository;
            _Itemrepository = ıtemrepository;
            _productrepository = productrepository;
            _context = context;
        }

        public async Task AddCartOrGetCart(BasketItemDto item, bool entry = true)
        {
            var customerExists = await _customerrepository.Query().Where(c => c.CustomerId == item.CustomerId).FirstOrDefaultAsync() ??
                throw new BaseNotFoundException("Kullanıcı Bulunamadı");


            // Mevcut sepeti bul veya yeni bir sepet oluştur
            var entity = await _cartrepository.Query()
                .Include(x => x.CartItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.CustomerId == item.CustomerId);
            if (entity == null)
            {
                entity = new Cart { CustomerId = item.CustomerId };
                await _cartrepository.AddAsync(entity);
            }

            var product = await _productrepository.Query().AsTracking().Where(x => x.Stock > 0)
                .FirstOrDefaultAsync(x => x.ProductId == item.ProductId) ??
                 throw new BaseNotFoundException("Stok yetersiz");


            if (product != null)
            {
                var cartItem = entity.CartItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (cartItem == null)
                {
                    entity.CartItems.Add(new CartItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        CartId = entity.CartId,
                        UpdateTime = DateTime.UtcNow.AddHours(3),
                    });

                    await _cartrepository.UpdateAsync(entity);

                    // Stok güncelleme
                    product.Stock -= item.Quantity;
                    await _productrepository.UpdateAsync(product);
                }
                else
                {
                    // Mevcut cartItem'i güncelleme
                    if (entry)
                    {
                        if (product.Stock <= item.Quantity)
                        {
                            throw new Exception("Stok yetersiz");
                        }

                        cartItem.Quantity += item.Quantity;
                        await _cartrepository.UpdateAsync(entity);

                        // Stok güncelleme
                        product.Stock -= item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }
                    else
                    {
                        cartItem.Quantity -= item.Quantity;
                        await _cartrepository.UpdateAsync(entity);

                        // Stok iade
                        product.Stock += item.Quantity;
                        await _productrepository.UpdateAsync(product);
                    }
                }
            }


            // Tek bir SaveChangesAsync ile tüm işlemleri kaydet
            await _context.SaveChangesAsync();
        }

        public async Task<object> GetItemListAsync(Guid id)
        {

            var cart = await _cartrepository.Query()
                .Include(x => x.CartItems)
                .ThenInclude(y => y.Product)
                .Where(x => x.CustomerId == id)
                .Select(x => new
                {
                    CartItems = x.CartItems.Select(ci => new//cartitem içine girdik.
                    {
                        ProductName = ci.Product.Name,
                        ProductPrice = ci.Product.Price,
                        UpdateTimes = ci.UpdateTime,
                        ProductTotal = ci.Quantity * ci.Product.Price
                    }).ToList(),
                })
                .FirstOrDefaultAsync() ??
                throw new NotFoundException("Liste Bulunamadı");


            var ProductTotal = cart.CartItems.Sum(item => item.ProductTotal);


            return new
            {
                CartItems1 = cart.CartItems,
                ProductTotals = ProductTotal,
                ItemCount = cart.CartItems.Count
            };
        }
    }
}

