namespace ThucTap.Payment_Services.Momo.Responses
{
    public class MomoOneTimePaymentCreateLinkResponses
    {
        public string? partnerCode { get; set; } 
        public string? orderId { get; set; }
        public long amount { get; set; }
        public long responseTime { get; set; }
        public string? message { get; set; }
        public string? resultCode { get; set; }
        public string? payUrl { get; set; } 
        public string? deeplink { get; set; }
        public string? qrCodeUrl { get; set; } 
    }
}
