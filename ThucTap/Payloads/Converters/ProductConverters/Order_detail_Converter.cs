using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class Order_detail_Converter
    {
        private readonly AppDbContext _context;
        public Order_detail_Converter() 
        {
            _context = new AppDbContext();
        }
        public Order_detail_DTO EntityToDTO(Order_detail detail)
        {
            return new Order_detail_DTO
            {
                Created_at = DateTime.Now,
                Order_id = detail.Order_id,
                Price_total = detail.Price_total,
                Product_id = detail.Product_id,
                Quantity = detail.Quantity,
                Update_at = DateTime.Now,
            };
        }
    }
}
