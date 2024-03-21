﻿using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Repositorys
{
    public interface IUserRepository
    {
        public User Find(string email);
    }
}