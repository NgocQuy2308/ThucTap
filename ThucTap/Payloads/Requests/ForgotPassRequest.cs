using System.ComponentModel.DataAnnotations;

namespace ThucTap.Payloads.Requests
{
    public class ForgotPassRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string User_name { get; set; }
        public string password { get; set; }
    }
}
