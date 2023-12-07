using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Product_review
    {
        [Key]
        public int Product_review_id { get; set; }
        public int Product_id { get; set; }
        public virtual Product? Product { get; set; }
        public int User_id { get; set; }
        public virtual User? User { get; set; }
        public string? Content_rated { get; set; }
        public int Point_evaluation { get; set; }
        public string? Content_seen { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }


    }
}
