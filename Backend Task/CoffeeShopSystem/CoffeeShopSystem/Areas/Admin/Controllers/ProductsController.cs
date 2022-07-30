using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShopSystem.Models.Entities;
using CoffeeShopSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoffeeShopSystem.Constant;

namespace CoffeeShopSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IAsyncRepository<Product> _productRepository;

       public ProductsController(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        #region GetAll
        // GET: Admin/Products
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Index()
        {
            var list = await _productRepository.GetALlAsync();
              return
                  list is not null ? 
                          View(list) :
                          Problem("No Product has been found  is null.");
        }
        #endregion

        #region Create
        // GET: Admin/Products/Create
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Create([Bind("Name,Description,SmallCupSize_Price,MediumCupSize_Price,LargeCupSize_Price,ExtraLargeCupSize_Price")] Product product)
        {
            if (ModelState.IsValid)
            {
               await _productRepository.AddAsync(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        #endregion

        #region Edit
        // GET: Admin/Products/Edit/5
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var product = await _productRepository.GetByIdAsync((int)id);
            
            if (product is null)
                return NotFound();

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SmallCupSize_Price,MediumCupSize_Price,LargeCupSize_Price,ExtraLargeCupSize_Price")] Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                   await  _productRepository.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_productRepository.GetByIdAsync(product.Id) is null)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        #endregion

        #region Delete
        // GET: Admin/Products/Delete/5
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var product = await _productRepository.GetByIdAsync((int)id);

            if (product is null)
                return NotFound();

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync((int)id);

            if (product is not null)
                await _productRepository.Delete(product);
            
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
