using Qz.Domain.Repositorys.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Issues
{
    public interface IIssueRepository : IRepository<Issue>
    {
        IEnumerable<Issue> MyIssue(long orgId, long userId);
    }
}
