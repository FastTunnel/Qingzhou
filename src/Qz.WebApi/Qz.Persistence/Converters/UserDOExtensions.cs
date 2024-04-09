using Qz.Application.Contracts.Dtos;
using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Assemblers
{
    public static class UserDOExtensions
    {
        public static User ToUser(this UserDO userDo)
        {
            return new User
            {
                Name = userDo.user_name,
                RegTime = userDo.reg_time,
                Password = userDo.password,
                Id = userDo.user_id
            };
        }
    }
}
