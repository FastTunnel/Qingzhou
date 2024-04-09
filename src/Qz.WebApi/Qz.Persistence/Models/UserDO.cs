using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Domains
{
    public class UserDO
    {
        public long user_id { get; set; }

        public required string user_name { get; set; }

        public required string password { get; set; }

        public required long reg_time { get; set; }
    }
}
