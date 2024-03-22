using Qz.Domain.Repository.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Domains
{
    public class User : Aggregate<Types.Identifier>
    {
        public Types.Identifier Id { get; set; }

        public required string Name { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        public required DateTime RegTime { get; set; }

        public bool CheckPass(string password)
        {
            return Password == password;
        }

        public string GenToken()
        {
            return "---------token---------";
        }

        public Types.Identifier GetId()
        {
            return Id;
        }
    }
}
