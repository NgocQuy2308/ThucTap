using ThucTap.Entity;

namespace ThucTap.Payloads.DTOs.ProductDTOs
{
    public class OrderDTO
    {
        public int? Payment_id { get; set; }
        public int User_id { get; set; }
        public double? Original_price { get; set; }
        public double? Actual_price { get; set; }
        public string? Full_name { get; set; }
        public string? Phone { get; set; }
        public int Order_status_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IQueryable<Order_detail_DTO>? Details { get; set; }
        public IQueryable<Order_Status_DTO>? Status_DTOs { get; set; }
    }
}
