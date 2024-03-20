using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class TeamRepository
    {
        public Team AddTeam(Team team)
        {
            team.Id = 1;
            return team;
        }

        public Team Find(long id)
        {
            return new Team
            {
                Id = id,
                Name = "",
                Description = "",
                CreatedTime = DateTime.Now,
                CreateUserId = 1,
            };
        }
    }
}
