using Qz.Domain.Base.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Users
{
    public class User : Aggregate<long>
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }

        public required long RegTime { get; set; }

        public bool CheckPass(string password)
        {
            return Password == password;
        }
    }
}
