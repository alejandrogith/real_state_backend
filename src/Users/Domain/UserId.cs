
using real_state_backend.src.Shared.Domain.ValueObject;

namespace real_state_backend.src.Users.Domain
{
    public class UserId : Uuid
    {
        public UserId(string value) : base(value)
        {
        }
    }

}