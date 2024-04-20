using Qz.Application.Contracts.Dtos;
using Qz.Domain.Models;
using Qz.Persistence.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Converters
{
    public static class UserDOExtensions
    {
        public static User ToUser(this UserEntity userDo)
        {
            return new User
            {
                Name = userDo.name,
                RegTime = userDo.reg_time,
                Password = userDo.password,
                Id = userDo.id
            };
        }
    }
}
