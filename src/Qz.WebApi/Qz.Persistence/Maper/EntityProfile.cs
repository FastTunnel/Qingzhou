using AutoMapper;
using Qz.Domain.Projects;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Domain.Workitems;
using Qz.Persistence.Entitys;
using Organization = Qz.Domain.Organization.Organization;

namespace Qz.Persistence.Maper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Organization, OrganizationEntity>().ReverseMap();
            CreateMap<TodoItem, TodoItemEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Workitem, WorkitemEntity>().ReverseMap();
            CreateMap<Project, ProjectEntity>().ReverseMap();
        }
    }
}
