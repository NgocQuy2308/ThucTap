namespace ThucTap.Payloads.DTOs
{
    public class UserDTO
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}
