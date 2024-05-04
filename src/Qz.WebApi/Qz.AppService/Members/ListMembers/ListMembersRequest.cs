using Qz.Application.Base.Commands;
using Qz.Application.Orgs.AddOrg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Members.ListMembers
{
    public class ListMembersRequest : ICommand<ListMembersResponse>
    {
        public long OrganizationId { get; set; }
    }
}
