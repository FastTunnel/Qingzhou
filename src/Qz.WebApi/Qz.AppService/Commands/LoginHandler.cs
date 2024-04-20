using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Qz.Application.Contracts.Base;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Domain;
using Qz.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Qz.Application.Commands
{
    public class LoginHandler : ILoginHandler
    {
        readonly IUserRepository userRepository;
        readonly IDistributedCache distributedCache;
        IConfiguration config;
        const string Key = "User";

        public LoginHandler(IUserRepository userRepository, IDistributedCache distributedCache, IConfiguration config)
        {
            this.userRepository = userRepository;
            this.distributedCache = distributedCache;
            this.config = config;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRepository.FindByUserName(request.UserName);
            if (user == null)
            {
                throw new Exception("账号或密码错误");
            }

            var success = user.CheckPass(request.Password);
            if (!success)
            {
                throw new Exception("账号或密码错误");
            }

            var claims = new[] {
                    new Claim(Key,  JsonSerializer.Serialize( new CurrentUser{
                        UserId = user.Id,
                        UserName = user.Name,
                    })),
             };

            var token = JWTTokenManager.GenerateToken(claims, config.GetSection("JWT")["SigningKey"]);
            return Task.FromResult(new LoginResponse
            {
                Token = token
            });
        }
    }
}
