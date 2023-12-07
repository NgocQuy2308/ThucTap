using ThucTap.Enumerates;

namespace ThucTap.Payloads.Requests.ReviewRequests
{
    public class Request_Review
    {
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public string? Content_rated { get; set; }
        public int Point_evaluation { get; set; }
    }
}
