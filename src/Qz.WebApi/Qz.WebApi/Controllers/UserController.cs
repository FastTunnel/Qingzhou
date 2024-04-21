using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Contracts.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public QzResponse Put(TodoDto item)
        {
            return Success($"insert");
        }

        [HttpPost]
        public QzResponse Post(TodoDto item)
        {
            return Success($"updated");
        }

        [HttpDelete]
        public QzResponse Delete([Range(1, double.MaxValue)] long Id)
        {
            return Success($"deleted");
        }
    }
}
