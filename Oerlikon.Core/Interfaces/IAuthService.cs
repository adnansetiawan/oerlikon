using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oerlikon.Core.Models.Users;

namespace Oerlikon.Core.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
