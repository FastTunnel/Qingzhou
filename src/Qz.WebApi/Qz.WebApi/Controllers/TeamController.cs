using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Contracts;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Teams.AddTeam;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IMediator mediator;

        public TeamController(ILogger<TeamController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPut]
        public async Task<QzResponse> Put(AddTeamCommand request)
        {
            request.UserId = CurrentUser.UserId;
            return Success(await mediator.Send(request));
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
