﻿using Qz.Application.Base.Commands;
using Qz.Application.Contracts.Dtos;
using System.ComponentModel.DataAnnotations;


namespace Qz.Application.User.Login
{
    public class LoginCommand : ICommand<LoginResponse>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
