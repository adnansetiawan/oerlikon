﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Exceptions
{
    public class AuthException : Exception
    {
        
        public AuthException(string message) : base(message)
        {
        }
    }
    public class BadRequestException : Exception
    {

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
