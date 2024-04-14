using Dapper.Contrib.Extensions;
using Mysqlx.Crud;
using Qz.Application.Contracts.Repositorys;
using Qz.Domain.DomainPrimitive;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using Qz.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Repositorys
{
    public class TeamRepository : ITeamRepository
    {
        QingZhouDbContext dbContext;

        public TeamRepository(QingZhouDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
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
                id = id,
                name = "",
                describe = "",
                created_time = DateTime.Now.ToLong(),
                created_user = 1,
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

        public void Remove(Team team)
        {
            dbContext.Delete(team.Id);
        }

        public void Save(Team team)
        {
            dbContext.Insert(team);
        }
    }
}
