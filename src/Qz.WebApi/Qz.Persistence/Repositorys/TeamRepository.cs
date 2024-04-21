using AutoMapper;
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
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public TeamRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
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
                Id = id,
                Name = "",
                Describe = "",
                CreatedTime = DateTime.Now.ToLong(),
                CreatedUser = 1,
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
                Name = team.Name.Name,
                CreatedTime = DateTime.Now.ToLong(),
                CreatedUser = team.CreateUserId,
                Describe = team.Description,
            });

            team.Id = new Identifier(Convert.ToInt64(id));
            return team.Id.Value;
        }
    }
}
