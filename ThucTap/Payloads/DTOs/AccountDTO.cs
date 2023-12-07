using ThucTap.Entity;

namespace ThucTap.Payloads.DTOs
{
    public class AccountDTO
    {
        public string User_name { get; set; }
        public string? Avatar { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int? DecentralizationId { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public IQueryable<UserDTO>? user { get; set; }

    }
}
