using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Models.Users
{
    public class UserLoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public Guid UserUID { get; set; }
        
        public string AccessToken { get; set; }

    }
}
