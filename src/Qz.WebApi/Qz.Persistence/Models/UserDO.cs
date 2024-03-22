using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Domains
{
    public class UserDO
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        public required DateTime RegTime { get; set; }
    }
}
