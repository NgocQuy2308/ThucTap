namespace ThucTap.Payloads.Requests.OrderRequests
{
    public class Buy_OrderRequest
    {
        public int User_Id { get; set; }
        public string? Name_Customer { get; set; }
        public List<Buy_OrderDetailRequest>? detailRequests { get; set; }
        public int Payment_Id { get; set; }
    }
}
