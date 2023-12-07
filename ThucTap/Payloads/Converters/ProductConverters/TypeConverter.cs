using ThucTap.Entity;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.Payloads.Converters.ProductConverters
{
    public class TypeConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProductConverter productConverter;
        public TypeConverter()
        {
            _appDbContext = new AppDbContext();
            productConverter = new ProductConverter();
        }
        public TypeDTO EntityToDTO(Product_type _Type)
        {
            return new TypeDTO
            {
                Image_type_product = _Type.Image_type_product,
                Name_product_type = _Type.Name_product_type,
                Products = _appDbContext.Products.Where(x=>x.Product_type_id == _Type.Product_type_id)
                                                 .Select(x=>productConverter.EntityToDTO(x))
            };
        }
    }
}
