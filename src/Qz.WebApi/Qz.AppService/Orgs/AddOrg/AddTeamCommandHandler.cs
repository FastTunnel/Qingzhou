using AutoMapper;
using Qz.Application.Base.Commands;
using Qz.Domain.Orgs;
using Qz.Domain.Types;

namespace Qz.Application.Orgs.AddOrg
{
    public class AddTeamCommandHandler : ICommandHandler<AddTeamCommand, AddTeamResponse>
    {
        readonly IOrgRepository teamRepository;
        IMapper mapper;

        public AddTeamCommandHandler(IOrgRepository teamRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.teamRepository = teamRepository;
        }

        public Task<AddTeamResponse> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            var team = Org.CreateTeam(request.Name, request.Description, request.UserId.Value);

            var id = teamRepository.Save(team);
            team.Id = id;

            return Task.FromResult(new AddTeamResponse
            {
                TeamId = id
            });
        }
    }
}
