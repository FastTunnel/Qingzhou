﻿using Qz.Domain.Base.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User? FindByUserName(string email);
    }
}
