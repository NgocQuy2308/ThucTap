using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class ProductConverter
    {
        private readonly AppDbContext _context;
        private readonly ReviewConverter _reviewConverter;
        public ProductConverter() 
        {
            _context = new AppDbContext();
            _reviewConverter = new ReviewConverter();
        }
        public ProductDTO EntityToDTO(Product product)
        {
            return new ProductDTO
            {
                Avatar_image_product = product.Avatar_image_product,
                Discount = product.Discount,
                Name_product = product.Name_product,
                Number_of_view = product.Number_of_view,
                Price = product.Price,
                Status = product.Status,
                Title = product.Title,
                Reviews = _context.Product_Reviews.Where(x=>x.Product_id == product.Product_id)
                                                  .Select(x=>_reviewConverter.EntityToDTO(x))
            };
        }
    }
}
