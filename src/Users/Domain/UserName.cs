
using real_state_backend.src.Shared.Domain.ValueObject;

namespace real_state_backend.src.Users.Domain
{
    public class UserName : StringValueObject
    {
        public UserName(string value) : base(value)
        {
        }
    }
}