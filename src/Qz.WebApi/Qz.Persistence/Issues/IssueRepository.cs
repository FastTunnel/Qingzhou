using AutoMapper;
using Dommel;
using Qz.Domain.Issues;
using Qz.Domain.Repositorys.Base;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Issues
{
    public class IssueRepository : IIssueRepository
    {
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public IssueRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Attach(Issue aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Issue aggregate)
        {
            throw new NotImplementedException();
        }

        public Issue? Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Issue> MyIssue(long orgId, long userId)
        {
            var res = dbContext.Select<IssueEntity>(x => x.CreatedBy == userId && x.OrgId == orgId);
            return res.Select(mapper.Map<Issue>);
        }

        public void Remove(Issue aggregate)
        {
            throw new NotImplementedException();
        }

        public long Save(Issue aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
