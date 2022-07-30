using CoffeeShopSystem.Constant;
using CoffeeShopSystem.Models;
using CoffeeShopSystem.Models.Entities;
using CoffeeShopSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopSystem.Services.Implementation
{
    public class DbInitializer : IDbInitializer
    {
        private ApplicationDbContext _db;
        private readonly UserManager<Staff> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<Staff> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            //check migrations if they are not applied, no need to updata-database command again
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Cashier)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new Staff
                {
                    UserName = "Admin@CoffeeShop.com",
                    Email = "Admin@CoffeeShop.com",
                    FullName = "Admin",
                }, "Admin123*").GetAwaiter().GetResult();

                Staff admin = _db.Staff.FirstOrDefault(u => u.Email == "Admin@CoffeeShop.com");

                _userManager.AddToRoleAsync(admin, SD.Role_Admin).GetAwaiter().GetResult();
            }
        }
    }
}
