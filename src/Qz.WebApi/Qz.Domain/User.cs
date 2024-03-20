using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime  RegTime { get; set; }

        public bool CheckPass(string password)
        {
            return Password == password;
        }

        public string GenToken()
        {
            return "---------token---------";
        }
    }
}
