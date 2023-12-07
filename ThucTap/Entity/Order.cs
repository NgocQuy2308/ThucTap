using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Order
    {
        [Key]
        public int Order_id { get; set; }
        public int Payment_id { get; set; }
        public virtual Payment? Payment { get; set; }
        public int User_id { get; set; }
        public virtual User? User { get; set; }
        public double? Original_price { get; set; }
        public double? Actual_price { get; set; }
        public string? Full_name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int Order_status_id { get; set; }
        public virtual Order_status? Order_status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Order_detail>? Details { get; set; }
    }
}
