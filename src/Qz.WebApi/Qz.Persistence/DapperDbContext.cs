using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class DapperDbContext
    {
        protected DapperDBContextOptions options;

        public DapperDbContext(IOptions<DapperDBContextOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }
    }
}
