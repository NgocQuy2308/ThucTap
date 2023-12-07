using ThucTap.Entity;
using ThucTap.Handle.Email;
using ThucTap.Iservice;
using ThucTap.Payloads.Converters;
using ThucTap.Payloads.DTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Responses;

namespace ThucTap.services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly Responses<UserDTO> _response;
        private readonly UserConverter userConverter;
        public UserService()
        {
            _dbContext = new AppDbContext();
            _response = new Responses<UserDTO>();
            userConverter = new UserConverter();

        }

        public void DeleteUserRequest(int Id)
        {
            if (_dbContext.Users.Any(x => x.User_id == Id))
            {
                using (var trans = _dbContext.Database.BeginTransaction())
                {
                    var userDel = _dbContext.Users.Where(x => x.User_id == Id);
                    _dbContext.RemoveRange(userDel);
                    _dbContext.SaveChanges();
                    trans.Commit();
                }
            }
            else throw new Exception($"không tồn tại người dùng có id: {Id}. Vui lòng kiểm tra lại!");
        }

        public IQueryable<User> GetUsers(string? keyword, int? Id = null)
        {
            var result = _dbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(x => x.User_name.ToLower().Contains(keyword.ToLower()));
            }
            if (Id.HasValue)
            {
                result = result.Where(x => x.User_id == Id);
            }
            return result;
        }

        public Responses<UserDTO> UpdateUserRequest(UpdateUserRequest request)
        {
            var user = _dbContext.Users.FirstOrDefault(x=> x.User_id == request.user_Id);
            if (user == null)
            {
                return _response.ResponseError(StatusCodes.Status404NotFound, $"Không tìm thấy người dùng có Id: {request.user_Id}", null);
            }
            user.User_name = request.User_Name != null ? request.User_Name : user.User_name;
            user.Phone = request.Phone != null ? request.Phone : user.Phone;
            user.Address = request.Address != null ? request.Address : user.Address;
            user.Email = request.Email != null ? request.Email : user.Email;
            user.Update_at = DateTime.Now;
            user.Created_at = user.Created_at;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return _response.ResponseSuccess("Sửa thành công",userConverter.EntityToDTO(user));
        }
        public Responses<UserDTO> AddUserRequest(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
