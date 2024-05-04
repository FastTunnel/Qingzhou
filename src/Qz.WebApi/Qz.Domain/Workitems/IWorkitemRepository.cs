using Qz.Domain.Base.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Workitems
{
    public interface IWorkitemRepository : IRepository<Workitem>
    {
        IEnumerable<Workitem> MyIssue(long orgId, long userId);
    }
}
