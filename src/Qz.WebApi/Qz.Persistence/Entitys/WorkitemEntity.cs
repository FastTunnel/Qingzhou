using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class WorkitemEntity
    {
        public long Id { get; set; }

        public long OrgId { get; set; }

        public long ProjectId { get; set; }

        public required string IssueType { get; set; }

        public required string IssueTitle { get; set; }

        public long CreatedAt { get; set; }

        public long CreatedBy { get; set; }
    }
}
