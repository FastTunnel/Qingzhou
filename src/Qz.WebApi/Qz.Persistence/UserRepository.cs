using Qz.Application.Contracts.Repositorys;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
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
            return new User
            {
                Id = id,
                Email = "",
                Name = "",
                Password = "password",
                RegTime = DateTime.Now.AddDays(-1),
            };
        }

        public User FindByEmail(string email)
        {
            return new User
            {
                Id = new Identifier(1),
                Email = "",
                Name = "",
                Password = "password",
                RegTime = DateTime.Now.AddDays(-1),
            };
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
