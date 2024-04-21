using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Users
{
    public interface IUserRepository : IRepository<User, Identifier>
    {
        User? FindByUserName(string email);
    }
}
