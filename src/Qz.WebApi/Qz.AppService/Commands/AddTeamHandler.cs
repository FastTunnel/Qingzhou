using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Interfaces;
using Qz.Domain;
using Qz.Domain.Domains;
using Qz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Commands
{
    public class AddTeamHandler : IAddTeamHandler
    {
        readonly TeamRepository teamRepository;
        public AddTeamHandler(TeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task<AddTeamResponse> Handle(AddTeamRequest request, CancellationToken cancellationToken)
        {
            var team = new Team()
            {
                Name = request.Name,
                CreatedTime = DateTime.UtcNow,
                CreateUserId = 1,
                Description = request.Description,
            };

            team = teamRepository.AddTeam(team);
            return Task.FromResult(new AddTeamResponse { TeamId = team.Id });
        }
    }
}
