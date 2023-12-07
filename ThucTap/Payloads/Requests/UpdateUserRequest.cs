using System.ComponentModel.DataAnnotations;

namespace ThucTap.Payloads.Requests
{
    public class UpdateUserRequest
    {
        public int user_Id {get; set;}
        public string User_Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
