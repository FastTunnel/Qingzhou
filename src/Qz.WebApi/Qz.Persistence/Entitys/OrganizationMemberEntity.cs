using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class OrganizationMemberEntity
    {
        public long TeamId {  get; set; }

        public long UserId { get; set; }

        public long JoinTime { get; set; }
    }
}
