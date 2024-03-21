using Qz.Application.Contracts.Repositorys;
using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class UserRepository : IUserRepository
    {
        public User Find(string email)
        {
            return new User
            {
                Id = 1,
                Email = email,
                Name = "",
                Password = "password",
                RegTime = DateTime.Now.AddDays(-1),
            };
        }
    }
}
