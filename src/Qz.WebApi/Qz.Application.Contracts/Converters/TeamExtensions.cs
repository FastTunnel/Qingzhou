using Qz.Application.Contracts.Dtos;
using Qz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Converters
{
    public static class TeamExtensions
    {
        public static AddTeamResponse ToAddTeamResponse(this Team team)
        {
            return new AddTeamResponse { TeamId = team.Id.Value };
        }
    }
}
