using ThucTap.Entity;
using ThucTap.Payloads.DataResponses;
using ThucTap.Payloads.DTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Responses;

namespace ThucTap.Iservice
{
    public interface IRegisterService
    {
        Task<Responses<string>> AddAccountRequest(RegisterRequest request);
        Responses<DataResponsesToken> LoginAccountRequest(UserRequests request);
        Responses<string> ForgotAccountRequest(ForgotPassRequest request);
        Responses<string> ChangedPassRequest(ChangedPassRequest request);
        DataResponsesToken GenerateAccessToken(Account account);
        DataResponsesToken RenewAccessToken(Request_RenewToken request);
        Task<Responses<string>> ConfirmCreateNewAccount(Request_ConfirmCreateAccount request);
    }
}
