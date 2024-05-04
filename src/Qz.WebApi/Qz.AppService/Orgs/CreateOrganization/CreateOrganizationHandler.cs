using AutoMapper;
using Qz.Application.Base.Commands;
using Qz.Domain.Orgs;
using Qz.Domain.Types;

namespace Qz.Application.Orgs.AddOrg
{
    public class CreateOrganizationHandler : ICommandHandler<CreateOrganizationRequest, ListMembersResponse>
    {
        readonly IOrganizationRepository teamRepository;
        IMapper mapper;

        public CreateOrganizationHandler(IOrganizationRepository teamRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.teamRepository = teamRepository;
        }

        public Task<ListMembersResponse> Handle(CreateOrganizationRequest request, CancellationToken cancellationToken)
        {
            var team = Organization.CreateTeam(request.Name, request.Description, request.UserId.Value);

            var id = teamRepository.Save(team);
            team.Id = id;

            return Task.FromResult(new ListMembersResponse
            {
                TeamId = id
            });
        }
    }
}
