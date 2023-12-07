using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class OrderConverter
    {
        private readonly AppDbContext _context;
        private readonly Order_detail_Converter _detail;
        private readonly Order_Status_Converter _status;

        public OrderConverter() 
        {
            _context = new AppDbContext();
            _detail = new Order_detail_Converter();
            _status = new Order_Status_Converter();
        }
        public OrderDTO EntityToDTO(Order order)
        {
            return new OrderDTO
            {
                Actual_price = order.Actual_price,
                Created_at = order.Created_at,
                Full_name = order.Full_name,
                Order_status_id = order.Order_status_id,
                Original_price = order.Original_price,
                Payment_id = order.Payment_id,
                Update_at = order.Update_at,
                User_id = order.User_id,
                Details = _context.Order_Details.Where(x => x.Order_id == order.Order_id)
                                                .Select(x => _detail.EntityToDTO(x)),
                Status_DTOs = _context.Order_Statuses.Where(x => x.Order_status_id == order.Order_status_id)
                                                     .Select(x => _status.EntityToDTO(x)),
            };
        }
    }
}
