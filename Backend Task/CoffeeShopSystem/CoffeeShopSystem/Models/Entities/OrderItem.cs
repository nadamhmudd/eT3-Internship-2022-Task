using System.ComponentModel.DataAnnotations;

namespace CoffeeShopSystem.Models.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [MaxLength(10)]
        public string CupSize { get; set; }

        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
