using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Carts
    {
        [Key]
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public virtual User? User { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Cart_item> Cart_items { get; set;}
    }
}
