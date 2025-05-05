using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Models.Users
{
    public class UserRegisterRequest 
    {
        public string Name { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; }

       
    }
    public class UserRegisterResponse
    {
        public Guid UserUID { get; set; }
       
    }
}
