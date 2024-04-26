using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Qz.Application.Base;
using Qz.Application.Base.Commands;
using Qz.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Qz.Application.User.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        readonly IUserRepository userRepository;
        readonly IDistributedCache distributedCache;
        IConfiguration config;
        const string Key = "User";

        public LoginCommandHandler(IUserRepository userRepository, IDistributedCache distributedCache, IConfiguration config)
        {
            this.userRepository = userRepository;
            this.distributedCache = distributedCache;
            this.config = config;
        }

        public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
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
                    new Claim(Key,  JsonSerializer.Serialize(new CurrentUser{
                        UserId = user.Id,
                        UserName = user.Name,
                        //Teams = teams
                    })),
            };

            var token = JWTTokenManager.GenerateToken(claims, config.GetSection("JWT")["SigningKey"]);

            return Task.FromResult(new LoginResponse
            {
                Token = token,
            });
        }
    }
}
