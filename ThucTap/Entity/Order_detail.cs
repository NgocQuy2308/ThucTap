using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Order_detail
    {
        [Key]
        public int Order_detail_id { get; set; }
        public int Order_id { get; set; }
        public virtual Order? Order { get; set; }
        public int Product_id { get; set; }
        public virtual Product? Product { get; set; }
        public double Price_total { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}
