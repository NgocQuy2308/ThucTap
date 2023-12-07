using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using ThucTap.Helpers;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using ThucTap.Payment_Services.Momo.Responses;

namespace ThucTap.Payment_Services.Momo.Request
{
    public class MomoOneTimePayment_Request
    {
        public MomoOneTimePayment_Request(string partnerCode, string requestId,
            long amount, string orderId, string orderInfo, string redirectUrl,
            string ipnUrl, string requestType, string extraData, string lang = "vi")
        {
            this.partnerCode = partnerCode;
            this.requestId = requestId;
            this.amount = amount;
            this.orderId = orderId;
            this.orderInfo = orderInfo;
            this.redirectUrl = redirectUrl;
            this.ipnUrl = ipnUrl;
            this.requestType = requestType;
            this.extraData = extraData;
            this.lang = lang;
        }
        public string? partnerCode { get; set; }
        public string? requestId { get; set; }
        public long amount { get; set; }
        public string? orderId { get; set; }
        public string? orderInfo { get; set; }
        public string? redirectUrl { get; set; }
        public string? ipnUrl { get; set; }
        public string? requestType { get; set; }
        public string? extraData { get; set; }
        public string? lang { get; set; }
        public string? signature { get; set; }

        public void MakeSignature(string accessKey, string secretKey)
        {
            var rawHash = "accessKey =" + accessKey +
                          "&amount =" + amount +
                          "&extraData =" + extraData +
                           "&ipnUrl =" + ipnUrl +
                           "&orderId =" + orderId +
                           "&orderInfo =" + orderInfo +
                           "&partnerCode =" + partnerCode +
                           "&redirectUrl =" + redirectUrl +
                           "&requestId =" + requestId +
                           "&requestType =" + requestType;
            this.signature = HashHelper.HmacSHA256(rawHash, secretKey);
        }
        public (bool, string?) GetLink(string paymentUrl)
        {
            using HttpClient client = new HttpClient();
            var requestData = JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            });
            var requestContent = new StringContent(requestData, Encoding.UTF8, "application/json");
            var createPaymentLinkRes = client.PostAsync(paymentUrl, requestContent).Result;
            if (createPaymentLinkRes.IsSuccessStatusCode)
            {
                var responsesContent = createPaymentLinkRes.Content.ReadAsStringAsync().Result;
                var responsesData = JsonConvert.DeserializeObject<MomoOneTimePaymentCreateLinkResponses>(responsesContent);
                if (responsesData.resultCode == "0")
                {
                    return (true, responsesData.payUrl);
                }
                return (false, responsesData.message);
            }
            return (false, createPaymentLinkRes.ReasonPhrase);
        }
    }
}
