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
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required DateTime CreatedTime { get; set; }

        public required long CreateUserId { get; set; }
    }
}
