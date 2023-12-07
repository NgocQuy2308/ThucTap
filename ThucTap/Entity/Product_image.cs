using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Product_image
    {
        [Key]
        public int Product_image_id { get; set; }
        public string Title { get; set; }
        public string Image_product { get; set; }
        public int Product_id { get; set; }
        public virtual Product? Product { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}
