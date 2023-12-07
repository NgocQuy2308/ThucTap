using System.ComponentModel.DataAnnotations;

namespace ThucTap.Payloads.Requests
{
    public class UserRequests
    {
        [Required(ErrorMessage = "User Name is required")]
        public string User_name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
