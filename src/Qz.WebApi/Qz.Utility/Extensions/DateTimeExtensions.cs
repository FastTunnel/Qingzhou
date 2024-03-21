using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Utility.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToLong(this DateTime time)
        {
            return long.Parse(time.ToString("yyyyMMddhhmmss"));
        }
    }
}
