using Microsoft.AspNetCore.Authentication;

namespace ThucTap.Payloads.DTOs.PaymentLink
{
    public class PaymentLinkDTOH
    {
        public string? PaymentID { get; set; }
        public string? PaymentUrl { get; set; }
    }
}
