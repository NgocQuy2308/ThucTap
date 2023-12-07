using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class Order_Status_Converter
    {
        private readonly AppDbContext _context;
        public Order_Status_Converter() 
        {
           _context = new AppDbContext();
        }
        public Order_Status_DTO EntityToDTO(Order_status order)
        {
           return new Order_Status_DTO
            {
                Status_name = order.Status_name,
            };
        }
    }
}
