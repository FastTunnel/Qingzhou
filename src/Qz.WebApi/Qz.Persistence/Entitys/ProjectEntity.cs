using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class ProjectEntity
    {
        public long Id { get; set; }

        public long OrgId { get; set; }

        public string ProjectName { get; set; }

        public string Describe { get; set; }

        public long CreatedAt { get; set; }

        public long CreatedBy { get; set; }

    }
}
