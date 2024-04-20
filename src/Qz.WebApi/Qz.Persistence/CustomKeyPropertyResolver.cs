using Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class CustomKeyPropertyResolver : IKeyPropertyResolver
    {
        public ColumnPropertyInfo[] ResolveKeyProperties(Type type)
        {
            return new[] { new ColumnPropertyInfo(type.GetProperties().Single(p => p.Name == $"{type.Name}Id"), isKey: true) };
        }
    }
}
