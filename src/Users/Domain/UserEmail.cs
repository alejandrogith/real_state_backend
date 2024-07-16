using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using real_state_backend.src.Shared.Domain.ValueObject;

namespace real_state_backend.src.Users.Domain
{
    public class UserEmail : StringValueObject
    {
        public UserEmail(string value) : base(value)
        {
        }
    }
}