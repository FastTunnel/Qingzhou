using Qz.Application.Contracts.Assemblers;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Application.Contracts.Repositorys;
using Qz.Domain;
using Qz.Domain.DomainPrimitive;
using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
