using System.ComponentModel.DataAnnotations;

namespace ThucTap.Payloads.Requests
{
    public class ChangedPassRequest
    {
        [Required]
        public string oldPasss { get; set; }
        [Required]
        public string newPasss { get; set; }
    }
}
