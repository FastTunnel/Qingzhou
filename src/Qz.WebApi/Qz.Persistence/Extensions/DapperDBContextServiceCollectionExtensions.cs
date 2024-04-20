using Dommel;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Extensions
{
    public static class DapperDBContextServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperDBContext<T>(this IServiceCollection services, Action<DapperDBContextOptions> setupAction)
            where T : DapperDbContext
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            // 表名
            DommelMapper.SetTableNameResolver(new CustomTableNameResolver());
            // 主键
            //DommelMapper.SetKeyPropertyResolver(new CustomKeyPropertyResolver());
            // 字段
            DommelMapper.SetColumnNameResolver(new CustomColumnNameResolver());

            DommelMapper.AddSqlBuilder(typeof(QingZhouDbContext), new MySqlSqlBuilder());

            DommelMapper.LogReceived = (sql) =>
            {
                Console.WriteLine(sql);
            };

            services.Configure(setupAction);
            services.AddScoped<T>();
            return services;
        }
    }
}
