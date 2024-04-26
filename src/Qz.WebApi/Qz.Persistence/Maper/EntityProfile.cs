using AutoMapper;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Persistence.Entitys;
using Organization = Qz.Domain.Orgs.Org;

namespace Qz.Persistence.Maper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Organization, OrgEntity>().ReverseMap();
            CreateMap<TodoItem, TodoItemEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
