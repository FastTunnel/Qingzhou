using Microsoft.Extensions.Caching.Distributed;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Application.Contracts.Repositorys;
using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Commands
{
    public class LoginHandler : ILoginHandler
    {
        readonly IUserRepository userRepository;
        readonly IDistributedCache distributedCache;

        public LoginHandler(IUserRepository userRepository, IDistributedCache distributedCache)
        {
            this.userRepository = userRepository;
            this.distributedCache = distributedCache;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRepository.FindByEmail(request.Email);
            if (user == null)
            {
                throw new Exception("账号或密码错误");
            }

            var success = user.CheckPass(request.Password);
            if (!success)
            {
                throw new Exception("账号或密码错误");
            }

            return Task.FromResult(new LoginResponse
            {
                Token = user.GenToken()
            });
        }
    }
}
