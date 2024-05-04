using MediatR;
using Qz.Application.Base.Commands;
using Qz.Application.Orgs.AddOrg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Members.GetMember
{
    public class MemberHandler : ICommandHandler<MemberRequest, MemberResponse>
    {
        public Task<MemberResponse> Handle(MemberRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
