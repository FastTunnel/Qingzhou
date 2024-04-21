using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Base
{
    public class CurrentUser
    {
        public required long UserId { get; set; }

        public required string UserName { get; set; }
    }
}
