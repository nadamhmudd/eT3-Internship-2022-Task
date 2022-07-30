using Microsoft.AspNetCore.Identity;

namespace CoffeeShopSystem.Models.Entities
{
    public class Staff : IdentityUser
    {
        public string FullName { get; set; }
    }
}
