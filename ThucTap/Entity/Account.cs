using System.ComponentModel.DataAnnotations;

namespace ThucTap.Entity
{
    public class Account
    {
        [Key]
        public int Account_id { get; set; }
        public string User_name { get; set; }
        public string? Avatar { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int? DecentralizationId { get; set; }
        public virtual Decentralization? Decentralization { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IEnumerable<User>? user { get; set; }
        public IEnumerable<RefreshToken>? Tokens { get; set; }
    }
}
