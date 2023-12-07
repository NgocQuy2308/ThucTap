using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Payment
    {
        [Key]
        public int Payment_id { get; set; }
        public string Payment_method { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
