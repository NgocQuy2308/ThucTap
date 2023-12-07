using ThucTap.Entity;

namespace ThucTap.Payloads.Requests.OrderRequests
{
    public class Buy_OrderDetailRequest
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
    }
}
