using ThucTap.Entity;

namespace ThucTap.Payloads.DTOs.ProductDTOs
{
    public class Order_detail_DTO
    {
        public int Order_id { get; set; }
        public int Product_id { get; set; }
        public double Price_total { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}
