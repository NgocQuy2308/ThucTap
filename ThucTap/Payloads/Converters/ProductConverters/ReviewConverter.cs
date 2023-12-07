using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class ReviewConverter
    {
        private readonly AppDbContext _appDbContext;
        public ReviewConverter() 
        {
            _appDbContext = new AppDbContext();
        }
        public ReviewDTO EntityToDTO(Product_review product_Review) 
        {
            return new ReviewDTO
            {
                User_id = product_Review.User_id,
                Content_rated = product_Review.Content_rated,
                Point_evaluation = product_Review.Point_evaluation,
            };
        }
    }
}
