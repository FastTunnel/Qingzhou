using AutoMapper;
using Qz.Application.Base.Commands;
using Qz.Application.Contracts.Dtos;
using Qz.Domain.Teams;
using Qz.Domain.Types;

namespace Qz.Application.Teams.AddTeam
{
    public class AddTeamCommandHandler : ICommandHandler<AddTeamCommand, AddTeamResponse>
    {
        readonly ITeamRepository teamRepository;
        IMapper mapper;

        public AddTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.teamRepository = teamRepository;
        }

        public Task<AddTeamResponse> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            var team = Team.CreateTeam(request.Name, request.Description, request.UserId.Value);

            var id = teamRepository.Save(team);
            team.Id = new Identifier(id);

            return Task.FromResult(new AddTeamResponse
            {
                TeamId = id
            });
        }
    }
}
