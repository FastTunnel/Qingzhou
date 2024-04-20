using Dommel;
using Mysqlx.Crud;
using Qz.Domain.Models;
using Qz.Domain.Repositorys;
using Qz.Domain.Types;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using Qz.Utility.Extensions;

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

        public TeamEntity Find(long id)
        {
            return new TeamEntity
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

        public long Save(Team team)
        {
            var id = dbContext.Insert(new TeamEntity
            {
                name = team.Name.Name,
                created_time = DateTime.Now.ToLong(),
                created_user = team.CreateUserId,
                describe = team.Description,
            });

            team.Id = new Identifier(Convert.ToInt64(id));
            return team.Id.Value;
        }
    }
}
