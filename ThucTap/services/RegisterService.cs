using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using ThucTap.Entity;
using ThucTap.Handle.Email;
using ThucTap.Iservice;
using ThucTap.Payloads.Converters;
using ThucTap.Payloads.DataResponses;
using ThucTap.Payloads.DTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Responses;
using ThucTap.services.implements;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using ThucTap.Payloads.DTOs.ProductDTOs;

namespace ThucTap.services
{
    public class RegisterService : BaseService, IRegisterService
    {
        private readonly Responses<string> _response;
        private readonly Responses<User> _responseOj;
        private readonly Responses<DataResponsesToken> _responsesToken;
        private readonly IConfiguration _configuration;
        public RegisterService(IConfiguration configuration)
        {
            _response = new Responses<string>();
            _responseOj = new Responses<User>();
            _configuration = configuration;
            _responsesToken = new Responses<DataResponsesToken>();
        }
        public string SendEmail(EmailTo emailTo)
        {
            if (!Validate.IsValidate(emailTo.Mail))
            {
                return "Định dạng email không hợp lệ";
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("gbmkayl99@gmail.com", "ffvfdpxzgerpaetw"),
                EnableSsl = true
            };
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("gbmkayl99@gmail.com");
                message.To.Add(emailTo.Mail);
                message.Subject = emailTo.Subject;
                message.Body = emailTo.Content;
                message.IsBodyHtml = true;
                smtpClient.Send(message);

                return "Xác nhận gửi email thành công, lấy mã để xác thực";
            }
            catch (Exception ex)
            {
                return "Lỗi khi gửi email: " + ex.Message;
            }
        }
        private int GenerateCodeActive()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
        public async Task<Responses<string>> ConfirmCreateNewAccount(Request_ConfirmCreateAccount request)
        {
            ConfirmEmail confirmEmail = _dbContext.ConfirmEmails.Where(x => x.CodeActive.Equals(request.ConfirmCode)).SingleOrDefault();
            if (confirmEmail == null)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Xác nhận đăng ký tài khoản thất bại", null);
            }
            if (confirmEmail.ExpiredTime < DateTime.Now)
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Mã xác nhận đã hết hạn", null);
            }
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.User_id == confirmEmail.User_id);
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Account_id == user.Account_id);
            account.Status = 1;
            _dbContext.ConfirmEmails.Remove(confirmEmail);
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
            return _response.ResponseSuccess("Xác nhận đăng ký tài khoản thành công", "");
        }
        public async Task <Responses<string>> AddAccountRequest(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.User_name) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "vui lòng điền thông tin đầy đủ", "");
            }
            if (_dbContext.Accounts.Any(x => x.User_name.Equals(request.User_name)))
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Đăng Ký Thất Bại", "Tài khoản đã tồn tại");
            }
            if (_dbContext.Users.Any(x => x.Email.Equals(request.Email)))
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, "Đăng Ký Thất Bại", "Email đã tồn tại");
            }
            if (!Validate.IsValidate(request.Email))
            {
                return _response.ResponseError(StatusCodes.Status400BadRequest, "Định dạng Email không hợp lệ", "");
            }
            try
            {
                var accountNew = new Account();
                accountNew.Status = 0;
                accountNew.Update_at = DateTime.Now;
                accountNew.Avatar = "No Image";
                accountNew.Created_at = DateTime.Now;
                accountNew.DecentralizationId = 3;
                accountNew.User_name = request.User_name;
                accountNew.user = null;
                accountNew.ResetPasswordToken = null;
                accountNew.ResetPasswordTokenExpiry = null;
                accountNew.Password = BCryptNet.HashPassword(request.Password);
                await _dbContext.AddAsync(accountNew);
                await _dbContext.SaveChangesAsync();
                var userNew = new User();
                userNew.Address = null;
                userNew.Email = request.Email;
                userNew.Update_at = DateTime.Now;
                userNew.Created_at = DateTime.Now;
                userNew.Phone = null;
                var id = _dbContext.Accounts.OrderByDescending(x => x.Account_id)
                                            .Select(x => x.Account_id)
                                            .FirstOrDefault();
                userNew.Account_id = id;
                userNew.User_name = request.User_name;
                await _dbContext.AddAsync(userNew);
                await _dbContext.SaveChangesAsync();
                ConfirmEmail confirmEmail = new ConfirmEmail
                {
                    User_id = userNew.User_id,
                    IsConfirm = false,
                    ExpiredTime = DateTime.Now.AddHours(24),
                    CodeActive = "MyBugs" + "_" + GenerateCodeActive().ToString(),
                    RequiredDateTime = DateTime.Now
                };
                await _dbContext.ConfirmEmails.AddAsync(confirmEmail);
                await _dbContext.SaveChangesAsync();
                string message = SendEmail(new EmailTo
                {
                    Mail = request.Email,
                    Subject = "Nhận mã xác nhận để xác nhận đăng ký tài khoản mới từ đây: ",
                    Content = $"Mã kích hoạt của bạn là: {confirmEmail.CodeActive}, mã này có hiệu lực là 24 tiếng"
                });
                return _response.ResponseSuccess("Đăng Ký Thành Công", "Xin Mời Đăng Nhập");
            }
            catch (Exception ex)
            {

                return _response.ResponseError(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        public Responses<string> ChangedPassRequest(ChangedPassRequest request)
        {
            throw new NotImplementedException();
        }

        public Responses<string> ForgotAccountRequest(ForgotPassRequest request)
        {
            var email = _dbContext.Users.FirstOrDefault(x => x.Email == request.Email);
            var userName = _dbContext.Accounts.FirstOrDefault(x => x.User_name == request.User_name);

            if (email == null || userName == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, $"Tài khoản hoặc email này không tồn tại", "Mời nhập lại");
            }
            var id = _dbContext.Accounts.Where(x => x.User_name == request.User_name)
                            .Select(x => x.Account_id)
                            .FirstOrDefault();
            var check = _dbContext.Accounts.FirstOrDefault(x => x.Account_id == id);
            check.Password = BCryptNet.HashPassword(request.password);
            _dbContext.Accounts.Update(check);
            _dbContext.SaveChanges();
            return _response.ResponseSuccess("Đổi mật khẩu thành công", "");
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using(var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public DataResponsesToken GenerateAccessToken(Account account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value);

            var role = _dbContext.Decentralizations.SingleOrDefault(x => x.decentralization_id == account.DecentralizationId);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", account.Account_id.ToString()),
                    new Claim("email", _dbContext.Users.Where(x => x.Account_id == account.Account_id).Select(x => x.Email).FirstOrDefault().ToString()),
                    new Claim("role", role?.Authority_name ?? "")
                }),
                Expires = DateTime.Now.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            RefreshToken rf = new RefreshToken
            {
                Token = refreshToken,
                ExpiredTime = DateTime.Now.AddHours(3),
                Account_id = account.Account_id,
            };
            _dbContext.Tokens.Add(rf);
            _dbContext.SaveChanges();

            DataResponsesToken result = new DataResponsesToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return result;
        }

        public Responses<DataResponsesToken> LoginAccountRequest(UserRequests request)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.User_name.Equals(request.User_name));

            if (string.IsNullOrWhiteSpace(request.User_name) || string.IsNullOrWhiteSpace(request.Password))
            {
                return _responsesToken.ResponseError(StatusCodes.Status404NotFound, "Đăng Nhập Thất Bại", null);
            }
            bool checkPass = BCryptNet.Verify(request.Password, account.Password);
            if (!checkPass)
            {
                return _responsesToken.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không chính xác", null);
            }
            if (account.Status == 0)
            {
                return _responsesToken.ResponseError(StatusCodes.Status401Unauthorized, "Tài khoản chưa được Active", null);
            }
            return _responsesToken.ResponseSuccess("Đăng nhập thành công", GenerateAccessToken(account));
        }

        public DataResponsesToken RenewAccessToken(Request_RenewToken request)
        {
            throw new NotImplementedException();
        }
        private string ChangedPass(string oldPass, string newPass)
        {
            return "chưa biết làm gì ";
        }
    }
}
