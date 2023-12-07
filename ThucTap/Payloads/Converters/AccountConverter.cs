using ThucTap.Entity;
using ThucTap.Payloads.DTOs;

namespace ThucTap.Payloads.Converters
{
    public class AccountConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserConverter _userConverter;
        public AccountConverter()
        {
            _appDbContext = new AppDbContext();
            _userConverter = new UserConverter();
        }
        public AccountDTO EntityToDTO(Account account)
        {
            return new AccountDTO
            {
                DecentralizationId = account.DecentralizationId,
                Avatar = account.Avatar,
                Password = account.Password,
                Status = account.Status,
                User_name = account.User_name,
                Created_at = account.Created_at,
                Update_at = account.Update_at,
                ResetPasswordToken = account.ResetPasswordToken,
                ResetPasswordTokenExpiry = account.ResetPasswordTokenExpiry,
                user = _appDbContext.Users.Where(x=>x.Account_id == account.Account_id)
                                              .Select(x => _userConverter.EntityToDTO(x))
            };
        }
    }
}
