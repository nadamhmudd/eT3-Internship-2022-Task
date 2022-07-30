using CoffeeShopSystem.Models;
using CoffeeShopSystem.Models.Entities;
using CoffeeShopSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopSystem.Services.Implementation.Repositories
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
        #region Constructor(s)
        public OrderRepository(ApplicationDbContext dbContext)
            :base(dbContext)
        {
        }
        #endregion

        #region Actions
        public override async Task<Order> GetByIdAsync(int id)
        {
            return await (_dbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.Cashier)
                .Include(o => o.OrderItems).ThenInclude(i => i.Product))
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Order>> GetALlAsync()
        {
            return await (_dbContext.Orders
              .Include(o => o.Cashier)).ToListAsync();
        }
        #endregion
    }
}
