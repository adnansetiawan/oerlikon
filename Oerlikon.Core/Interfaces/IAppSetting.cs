using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Interfaces
{
    public interface IAppSetting
    {
        string JwtSecretKey { get; }
        string JwtIssuer { get; }
        string JwtAudience { get; }
    }
}
