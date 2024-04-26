using MediatR;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using Qz.Application.Base;
using Qz.Application.Orgs.AddOrg;
using Qz.Application.Orgs.ListOrg;
using Qz.Application.Todos.GetTodoItems;
using Qz.Domain.Orgs;
using Qz.Domain.Users;
using Qz.Persistence.Repositorys;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    public class OrgController : BaseController
    {
        private readonly ILogger<OrgController> _logger;
        private readonly IMediator mediator;
        ITeamRepository orgRepository;

        public OrgController(ILogger<OrgController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
            this.orgRepository = orgRepository;
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

        [HttpGet]
        public async Task<QzResponse> Get()
        {
            var res = await mediator.Send(new ListOrgCommand { UserId = CurrentUser.UserId });
            return Success(res);
        }
    }
}
