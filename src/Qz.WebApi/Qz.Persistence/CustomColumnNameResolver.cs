using Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class CustomColumnNameResolver : IColumnNameResolver
    {
        public string ResolveColumnName(PropertyInfo propertyInfo)
        {
            // Every column has prefix 'fld' and is uppercase.
            JsonNamingPolicy namingPolicy = JsonNamingPolicy.SnakeCaseLower;
            string snakeCaseString = namingPolicy.ConvertName(propertyInfo.Name);

            return snakeCaseString;
        }
    }
}
