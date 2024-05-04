using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Base.Types
{
    public class TeamName
    {
        public TeamName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (name.Length >= 20)
            {
                throw new ArgumentOutOfRangeException(nameof(name), name.Length, "超长");
            }

            Name = name;
        }

        public string Name { get; private set; }
    }
}
