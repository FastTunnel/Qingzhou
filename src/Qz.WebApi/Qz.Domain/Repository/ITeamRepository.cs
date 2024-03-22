using Qz.Domain.Domains;
using Qz.Domain.Repository.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Repositorys
{
    public interface ITeamRepository : IRepository<Team, Identifier>
    {
    }
}
