﻿using Qz.Application.Contracts.Dtos;
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
                Email = userDo.Email,
                Name = userDo.Name,
                RegTime = userDo.RegTime,
                Password = userDo.Password,
                Id = new Domain.Types.Identifier(userDo.Id)
            };
        }
    }
}
