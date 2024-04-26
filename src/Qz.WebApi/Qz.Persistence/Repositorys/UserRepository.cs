using AutoMapper;
using Dapper;
using Dommel;
using Qz.Domain.Orgs;
using Qz.Domain.Types;
using Qz.Domain.Users;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using Organization = Qz.Domain.Orgs.Org;

namespace Qz.Persistence.Repositorys
{
    public class UserRepository : IUserRepository
    {
        QingZhouDbContext dbContext;
        IMapper mapper;

        public UserRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Attach(User aggregate)
        {

        }

        public void Detach(User aggregate)
        {

        }

        public User? Find(long id)
        {
            var user = dbContext.Select<UserEntity>(x => x.id == id).FirstOrDefault();
            return mapper.Map<User>(user);
        }

        public User? FindByUserName(string userName)
        {
            var user = dbContext.Select<UserEntity>(x => x.name == userName).FirstOrDefault();
            return mapper.Map<User>(user);
        }


        public void Remove(User user)
        {
            dbContext.Delete<UserEntity>(mapper.Map<UserEntity>(user));
        }

        public long Save(User user)
        {
            dbContext.Insert<UserEntity>(mapper.Map<UserEntity>(user));
            return user.Id;
        }
    }
}
