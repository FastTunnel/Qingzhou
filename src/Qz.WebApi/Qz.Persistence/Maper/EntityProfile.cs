﻿using AutoMapper;
using Qz.Domain.Teams;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Persistence.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Maper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Team, TeamEntity>().ReverseMap();
            CreateMap<TodoItem, TodoItemEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
