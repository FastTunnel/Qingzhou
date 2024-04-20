using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Extensions
{
    public class DapperDBContextOptions : IOptions<DapperDBContextOptions>
    {
        public string Configuration { get; set; }

        public DapperDBContextOptions Value => throw new NotImplementedException();
    }
}
