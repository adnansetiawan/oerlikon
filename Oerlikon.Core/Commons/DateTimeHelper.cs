using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Commons
{
    public static class DateTimeHelper
    {
        public static DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
