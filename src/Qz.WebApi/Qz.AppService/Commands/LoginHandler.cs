using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Interfaces;
using Qz.Domain;
using Qz.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Commands
{
    public class LoginHandler : ILoginHandler
    {
        readonly UserRepository userRepository;

        public LoginHandler(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRepository.Find(request.Email);
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
