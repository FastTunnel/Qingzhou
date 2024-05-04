using Qz.Application.Base.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Members.ListMembers
{
    internal class ListMembersHandler : ICommandHandler<ListMembersRequest, ListMembersResponse>
    {
        public Task<ListMembersResponse> Handle(ListMembersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
