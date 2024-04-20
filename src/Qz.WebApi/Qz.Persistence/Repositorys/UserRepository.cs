using Dapper;
using Qz.Domain.Models;
using Qz.Domain.Repositorys;
using Qz.Domain.Types;
using Qz.Persistence.Converters;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Repositorys
{
    public class UserRepository : IUserRepository
    {
        QingZhouDbContext dbContext;

        public UserRepository(QingZhouDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Attach(User aggregate)
        {

        }

        public void Detach(User aggregate)
        {

        }

        public User? Find(Identifier id)
        {
            var sql = "select * from qz_user where id=1";
            var user = dbContext.QuerySingleOrDefault<UserEntity>(sql, null);
            return user?.ToUser();
        }

        public User? FindByUserName(string userName)
        {
            var sql = "select * from qz_user where name=@userName";
            var user = dbContext.QuerySingleOrDefault<UserEntity>(sql, new { userName });
            return user?.ToUser();
        }

        public void Remove(User aggregate)
        {
            throw new NotImplementedException();
        }

        public long Save(User aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
