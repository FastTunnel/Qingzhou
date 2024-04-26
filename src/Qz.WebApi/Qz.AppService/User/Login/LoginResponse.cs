using Qz.Domain.Orgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.User.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public IEnumerable<Org> Teams { get; set; }
    }
}
