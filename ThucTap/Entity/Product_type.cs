using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Product_type
    {
        [Key]
        public int Product_type_id { get; set; }
        public string Name_product_type { get; set; }
        public string Image_type_product { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Product>? Products { get; set;}
    }
}
