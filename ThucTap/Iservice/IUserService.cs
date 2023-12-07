using ThucTap.Entity;
using ThucTap.Payloads.DTOs;
using ThucTap.Payloads.Requests;
using ThucTap.Payloads.Responses;

namespace ThucTap.Iservice
{
    public interface IUserService
    {
        Responses<UserDTO>AddUserRequest(UpdateUserRequest request);
        public void DeleteUserRequest(int Id);
        Responses<UserDTO>UpdateUserRequest(UpdateUserRequest request);
        public IQueryable<User> GetUsers(string? keyword,int? Id=null);
    }
}
