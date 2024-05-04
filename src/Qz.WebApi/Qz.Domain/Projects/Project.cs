using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Projects
{
    public class Project
    {
        private Project(long OrgId, string projectName, string describe, long createdBy)
        {
            this.ProjectName = projectName;
            this.Describe = describe;
            this.OrgId = OrgId;
            this.CreatedBy = createdBy;
            CreatedAt = DateTime.Now.Ticks;
        }

        public long Id { get; set; }

        public long OrgId { get; set; }

        public string ProjectName { get; set; }

        public string Describe { get; set; }

        public long CreatedAt { get; set; }

        public long CreatedBy { get; set; }

        public static Project Create(long organizationId, string projectName, string describe, long createdBy)
        {
            return new Project(organizationId, projectName, describe, createdBy);
        }
    }
}
