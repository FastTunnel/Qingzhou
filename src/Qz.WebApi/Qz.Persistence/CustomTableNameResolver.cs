using Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class CustomTableNameResolver : ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
            string camelCaseString = type.Name;

            JsonNamingPolicy namingPolicy = JsonNamingPolicy.SnakeCaseLower;
            string snakeCaseString = namingPolicy.ConvertName(camelCaseString);

            return $"qz_{snakeCaseString.Replace("_entity", string.Empty)}";
        }
    }
}
