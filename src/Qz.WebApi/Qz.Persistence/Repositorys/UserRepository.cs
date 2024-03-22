using Qz.Application.Contracts.Assemblers;
using Qz.Application.Contracts.Repositorys;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public void Attach(User aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(User aggregate)
        {
            throw new NotImplementedException();
        }

        public User Find(Identifier id)
        {
            return new UserDO
            {
                Id = 100,
                Email = "",
                Name = "",
                Password = "password",
                RegTime = DateTime.Now.AddDays(-1),
            }.ToUser();
        }

        public User FindByEmail(string email)
        {
            return new UserDO
            {
                Id = 100,
                Email = "",
                Name = "",
                Password = "password",
                RegTime = DateTime.Now.AddDays(-1),
            }.ToUser();
        }

        public void Remove(User aggregate)
        {
            throw new NotImplementedException();
        }

        public void Save(User aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
