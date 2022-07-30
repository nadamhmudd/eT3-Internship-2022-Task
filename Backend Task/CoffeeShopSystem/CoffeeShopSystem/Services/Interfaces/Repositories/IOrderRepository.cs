using CoffeeShopSystem.Models.Entities;

namespace CoffeeShopSystem.Services.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
