namespace ThucTap.Payment_Services.Momo.Config
{
    public class MomoConfig
    {
        public static string ConfigName => "Momo";
        public string? PartnerCode { get; set; }
        public string? ReturnUrl { get; set; }
        public string? IpnUrl { get; set; }
        public string? AccessKey { get; set; }
        public string? SceretKey { get; set; }
        public string? PaymentUrl { get; set; }
    }
}
