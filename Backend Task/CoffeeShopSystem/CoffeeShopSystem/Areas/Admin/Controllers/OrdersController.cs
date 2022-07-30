using Microsoft.AspNetCore.Mvc;
using CoffeeShopSystem.Services.Interfaces;
using CoffeeShopSystem.Constant;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShopSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #region GetALL
        // GET: Admin/Orders
        public async Task<IActionResult> Index()
        {
             var list =  (await _orderRepository.GetALlAsync()).OrderByDescending(o => o.OrderDate);

            return View(list);
        }
        #endregion

        #region Get Details
        // GET: Admin/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var order = await _orderRepository.GetByIdAsync((int)id);
            if (order is null)
                return NotFound();

            return View(order);
        }
        #endregion
    }
}
