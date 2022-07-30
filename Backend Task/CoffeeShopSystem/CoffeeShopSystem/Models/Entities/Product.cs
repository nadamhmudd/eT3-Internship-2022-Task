using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopSystem.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [DisplayName("Small Cup Price")]
        public float SmallCupSize_Price { get; set; }

        [DisplayName("Medium Cup Price")]
        public float MediumCupSize_Price { get; set; }

        [DisplayName("Large Cup Price")]
        public float LargeCupSize_Price { get; set; }
        
        [DisplayName("Extra Large Cup Price")]
        public float ExtraLargeCupSize_Price { get; set; }
    }
}
