using Qz.Application.Base;
using Qz.Application.Base.Commands;
using Qz.Domain.Orgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Orgs.ListOrg
{
    public class ListOrgCommandHandler : ICommandHandler<ListOrgCommand, ListOrgResponse>
    {
        ITeamRepository orgRepository;

        public ListOrgCommandHandler(ITeamRepository orgRepository)
        {
            this.orgRepository = orgRepository;
        }

        public Task<ListOrgResponse> Handle(ListOrgCommand request, CancellationToken cancellationToken)
        {
            var orgs = orgRepository.ListOrgForCurrentUser(request.UserId) ?? Enumerable.Empty<Org>();

            return Task.FromResult(new ListOrgResponse
            {
                Orgs = orgs
            });
        }
    }
}
