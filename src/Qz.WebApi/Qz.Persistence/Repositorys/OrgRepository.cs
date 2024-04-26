using AutoMapper;
using Dapper;
using Dommel;
using Mysqlx.Crud;
using Qz.Domain.Orgs;
using Qz.Domain.Types;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using Qz.Utility.Extensions;
using Organization = Qz.Domain.Orgs.Org;

namespace Qz.Persistence.Repositorys
{
    public class OrgRepository : ITeamRepository
    {
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public OrgRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public void Attach(Organization aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Domain.Orgs.Org aggregate)
        {
            throw new NotImplementedException();
        }

        public Domain.Orgs.Org Find(long id)
        {
            return new Domain.Orgs.Org
            {
                Id = id,
                Name = "测试",
                Describe = "",
                CreatedTime = DateTime.Now,
                CreateUserId = 1,
            };
        }

        public IEnumerable<Organization> ListOrgForCurrentUser(long userId)
        {
            var sql = "select B.* from qz_org_member A left JOIN qz_org B ON A.org_id=B.id where user_id=@userId ";
            var list = dbContext.Query<OrgEntity>(sql, new { userId });

            return list.Select(x => mapper.Map<Organization>(x));
        }

        public void Remove(Domain.Orgs.Org team)
        {
            dbContext.Delete(team.Id);
        }

        public long Save(Domain.Orgs.Org team)
        {
            var id = dbContext.Insert(new OrgEntity
            {
                Name = team.Name,
                CreatedTime = DateTime.Now.ToLong(),
                CreatedUser = team.CreateUserId,
                Describe = team.Describe,
            });

            team.Id = Convert.ToInt64(id);
            return team.Id;
        }
    }
}
