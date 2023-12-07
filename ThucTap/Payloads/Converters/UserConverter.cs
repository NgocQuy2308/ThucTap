using ThucTap.Entity;
using ThucTap.Payloads.DTOs;

namespace ThucTap.Payloads.Converters
{
    public class UserConverter
    {
        public UserDTO EntityToDTO(User x)
        {
            return new UserDTO
            {
                User_id = x.User_id,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Update_at = x.Update_at,
                User_name = x.User_name,
                Created_at = x.Created_at,
            };
        }
    }
}
