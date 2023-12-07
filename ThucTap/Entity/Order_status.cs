using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Order_status
    {
        [Key]
        public int Order_status_id { get; set; }
        public string Status_name { get; set; }
        public IEnumerable<Order> orders { get; set; }
    }
}
