using ThucTap.Entity;

namespace ThucTap.Payloads.DTOs.ProductDTOs
{
    public class ReviewDTO
    {
        public int User_id { get; set; }
        public string Content_rated { get; set; }
        public int Point_evaluation { get; set; }
    }
}
