using Qz.Domain.DomainPrimitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Domains
{
    public class TeamDo
    {
        public long id { get; set; }

        public required string name { get; set; }

        public required string describe { get; set; }

        public required long created_time { get; set; }

        public required long created_user { get; set; }
    }
}
