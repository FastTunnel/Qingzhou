using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization = Qz.Domain.Orgs.Org;

namespace Qz.Domain.Orgs
{
    public interface ITeamRepository : IRepository<Org>
    {
        IEnumerable<Organization> ListOrgForCurrentUser(long userId);
    }
}
