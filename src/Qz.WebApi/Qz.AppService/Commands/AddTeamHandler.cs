using Qz.Application.Contracts.Converters;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Domain.Models;
using Qz.Domain.Repositorys;
using Qz.Domain.Types;

namespace Qz.Application.Commands
{
    public class AddTeamHandler : IAddTeamHandler
    {
        readonly ITeamRepository teamRepository;

        public AddTeamHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task<AddTeamResponse> Handle(AddTeamRequest request, CancellationToken cancellationToken)
        {
            var team = new Team()
            {
                Name = new TeamName(request.Name),
                CreatedTime = DateTime.UtcNow,
                CreateUserId = 1,
                Description = request.Description,
            };

            teamRepository.Save(team);
            return Task.FromResult(team.ToAddTeamResponse());
        }

        public Task<AddTeamResponse> Handle(AddTeamRequest request, long userId, CancellationToken cancellationToken)
        {
            var team = new Team()
            {
                Name = new TeamName(request.Name),
                CreatedTime = DateTime.UtcNow,
                CreateUserId = userId,
                Description = request.Description,
            };

            teamRepository.Save(team);
            return Task.FromResult(team.ToAddTeamResponse());
        }
    }
}
