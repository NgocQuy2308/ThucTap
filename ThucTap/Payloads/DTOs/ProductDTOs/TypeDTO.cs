namespace ThucTap.Payloads.DTOs.ProductDTOs
{
    public class TypeDTO
    {
        public string Name_product_type { get; set; }
        public string Image_type_product { get; set; }
        public IQueryable<ProductDTO>? Products { get; set; }
    }
}
