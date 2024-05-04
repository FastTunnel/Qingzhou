using Qz.Domain.Orgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Orgs.ListOrg
{
    public class ListOrgResponse
    {
        public required IEnumerable<Organization> Orgs { get; set; }
    }
}
