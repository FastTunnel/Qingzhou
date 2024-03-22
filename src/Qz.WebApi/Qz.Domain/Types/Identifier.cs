using Qz.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Types
{
    public class Identifier : IIdentifier
    {
        public Identifier(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            this.Value = id;
        }

        public long Value { get; private set; }
    }
}
