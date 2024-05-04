using AutoMapper;
using Dapper;
using Dommel;
using Mysqlx.Crud;
using Qz.Domain.Orgs;
using Qz.Domain.Types;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using Qz.Utility.Extensions;
using Organization = Qz.Domain.Orgs.Organization;

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

        public void Detach(Domain.Orgs.Organization aggregate)
        {
            throw new NotImplementedException();
        }

        public Domain.Orgs.Organization Find(long id)
        {
            return new Domain.Orgs.Organization
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

        public void Remove(Domain.Orgs.Organization team)
        {
            dbContext.Delete(team.Id);
        }

        public long Save(Domain.Orgs.Organization team)
        {
            var id = dbContext.Insert(new OrgEntity
            {
                Name = team.Name,
                CreatedAt = DateTime.Now.ToLong(),
                CreatedBy = team.CreateUserId,
                Describe = team.Describe,
            });

            team.Id = Convert.ToInt64(id);
            return team.Id;
        }
    }
}
