using Qz.Application.Base.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Orgs.ListOrg
{
    public class ListOrgCommand : ICommand<ListOrgResponse>
    {
        public long UserId { get; set; }
    }
}
