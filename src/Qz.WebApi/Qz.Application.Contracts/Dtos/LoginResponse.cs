using Qz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public Team[] teams { get; set; }
    }
}
