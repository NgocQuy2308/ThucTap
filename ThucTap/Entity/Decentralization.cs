using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Decentralization
    {
        [Key]
        public int decentralization_id { get; set; }
        public string Authority_name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<Account> accounts { get; set; }
    }
}
