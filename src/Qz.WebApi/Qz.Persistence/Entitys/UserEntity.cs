using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class UserEntity
    {
        public long id { get; set; }

        public required string name { get; set; }

        public required string password { get; set; }

        public required long RegAt { get; set; }
    }
}
