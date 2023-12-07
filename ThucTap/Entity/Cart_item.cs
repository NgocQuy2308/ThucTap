using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Cart_item
    {
        [Key]
        public int Cart_item_id { get; set; }
        public int Product_id { get; set; }
        public virtual Product? Product { get; set; }
        public int Cart_id { get; set; }
        public virtual Carts? Carts { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}
