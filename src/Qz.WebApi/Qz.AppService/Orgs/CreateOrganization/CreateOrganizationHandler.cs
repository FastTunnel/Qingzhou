using AutoMapper;
using Qz.Application.Base.Commands;
using Qz.Application.Members.ListMembers;
using Qz.Domain.Organization;

namespace Qz.Application.Orgs.CreateOrganization
{
    public class CreateOrganizationHandler : ICommandHandler<CreateOrganizationRequest, CreateOrganizationResponse>
    {
        readonly IOrganizationRepository teamRepository;
        IMapper mapper;

        public CreateOrganizationHandler(IOrganizationRepository teamRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.teamRepository = teamRepository;
        }

        public Task<CreateOrganizationResponse> Handle(CreateOrganizationRequest request, CancellationToken cancellationToken)
        {
            var team = Organization.CreateTeam(request.Name, request.Description, request.UserId.Value);

            var id = teamRepository.Save(team);
            team.Id = id;

            return Task.FromResult(new CreateOrganizationResponse
            {
                TeamId = id
            });
        }
    }
}
