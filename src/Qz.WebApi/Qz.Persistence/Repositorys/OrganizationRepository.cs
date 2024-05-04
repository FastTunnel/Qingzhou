using AutoMapper;
using Dapper;
using Dommel;
using Mysqlx.Crud;
using Qz.Domain.Organization;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using Qz.Utility.Extensions;
using Organization = Qz.Domain.Organization.Organization;

namespace Qz.Persistence.Repositorys
{
    public class OrganizationRepository : IOrganizationRepository
    {
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public OrganizationRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Attach(Organization aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Organization aggregate)
        {
            throw new NotImplementedException();
        }

        public Organization Find(long id)
        {
            return Organization.CreateTeam("测试", "desc", 1);
        }

        public IEnumerable<Organization> ListOrgForCurrentUser(long userId)
        {
            var sql = "select B.* from qz_org_member A left JOIN qz_org B ON A.org_id=B.id where user_id=@userId ";
            var list = dbContext.Query<OrganizationEntity>(sql, new { userId });

            return list.Select(x => mapper.Map<Organization>(x));
        }

        public void Remove(Organization team)
        {
            dbContext.Delete(team.Id);
        }

        public long Save(Organization team)
        {
            var id = dbContext.Insert(new OrganizationEntity
            {
                Name = team.Name,
                CreatedAt = DateTime.Now.ToTimestamp(),
                CreatedBy = team.CreateUserId,
                Describe = team.Describe,
            });

            team.Id = Convert.ToInt64(id);
            return team.Id;
        }
    }
}
