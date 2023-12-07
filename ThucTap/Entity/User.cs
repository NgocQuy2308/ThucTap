using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public int Account_id { get; set; }
        public virtual Account? Account { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Product_review>? product_Reviews {get; set; }
        public IEnumerable<ConfirmEmail>? ConfirmEmails {get; set; }
        public IEnumerable<Carts>? Carts { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
