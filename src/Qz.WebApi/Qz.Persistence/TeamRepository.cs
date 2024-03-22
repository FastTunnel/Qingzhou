using Qz.Application.Contracts.Repositorys;
using Qz.Domain.DomainPrimitive;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class TeamRepository : ITeamRepository
    {

        public void Attach(Team aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Team aggregate)
        {
            throw new NotImplementedException();
        }

        public TeamDo Find(long id)
        {
            return new TeamDo
            {
                Id = id,
                Name = "",
                Description = "",
                CreatedTime = DateTime.Now,
                CreateUserId = 1,
            };
        }

        public Team Find(Identifier id)
        {
            return new Team
            {
                Id = id,
                Name = new TeamName("测试"),
                Description = "",
                CreatedTime = DateTime.Now,
                CreateUserId = 1,
            };
        }

        public void Remove(Team aggregate)
        {
            throw new NotImplementedException();
        }

        public void Save(Team aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
