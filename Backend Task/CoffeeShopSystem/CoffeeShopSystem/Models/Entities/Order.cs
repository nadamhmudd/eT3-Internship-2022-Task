using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopSystem.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [MaxLength(10), DisplayName("Order Status")]
        public string OrderStatus { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Total")]
        public float OrderTotal { get; set; }

        public string CashierId { get; set; } //FK
        
        [ValidateNever, ForeignKey("CashierId")]
        public Staff Cashier { get; set; }

        //one to many relationship
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
