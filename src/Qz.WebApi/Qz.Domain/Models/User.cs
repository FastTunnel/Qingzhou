using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Models
{
    public class User : Aggregate<Identifier>
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }

        public required long RegTime { get; set; }

        public bool CheckPass(string password)
        {
            return Password == password;
        }

        public Identifier GetId()
        {
            return null;
        }
    }
}
