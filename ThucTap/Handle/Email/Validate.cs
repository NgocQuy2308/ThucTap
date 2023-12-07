using System.ComponentModel.DataAnnotations;

namespace ThucTap.Handle.Email
{
    public class Validate
    {
        public static bool IsValidate(string email)
        {
            var checkEmail = new EmailAddressAttribute();
            return checkEmail.IsValid(email);
        }
    }
}
