using AutoMapper;
using Dommel;
using Qz.Domain.Workitems;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Issues
{
    public class IssueRepository : IWorkitemRepository
    {
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public IssueRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Attach(Workitem aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Workitem aggregate)
        {
            throw new NotImplementedException();
        }

        public Workitem? Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Workitem> MyIssue(long orgId, long userId)
        {
            var res = dbContext.Select<WorkitemEntity>(x => x.CreatedBy == userId && x.OrgId == orgId);
            return res.Select(mapper.Map<Workitem>);
        }

        public void Remove(Workitem aggregate)
        {
            throw new NotImplementedException();
        }

        public long Save(Workitem aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
