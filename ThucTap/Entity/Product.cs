using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public int Product_type_id { get; set; }
        public virtual Product_type? Product_Type { get; set; }
        public string Name_product { get; set; }
        public double Price { get; set; }
        public string Avatar_image_product { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public int Number_of_view { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Cart_item>? Carts { get; set; }
        public IEnumerable<Order_detail>? Order_Details { get; set; }
        public IEnumerable<Product_image>? Product_Images { get; set; }
        public IEnumerable<Product_review>? Product_Reviews { get; set; }
    }
}
