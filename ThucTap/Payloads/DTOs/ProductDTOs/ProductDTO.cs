namespace ThucTap.Payloads.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public string Name_product { get; set; }
        public double Price { get; set; }
        public string Avatar_image_product { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public int Number_of_view { get; set; }
        public IQueryable<ReviewDTO> Reviews { get; set; }
    }
}
