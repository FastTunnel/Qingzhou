using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Orgs.AddOrg;
using Qz.Application.Orgs.ListOrg;
using Qz.Application.Todos.GetTodoItems;
using Qz.Domain.Orgs;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrganizationController : BaseController
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IMediator mediator;

        public OrganizationController(ILogger<OrganizationController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPut]
        public async Task<QzResponse<ListMembersResponse>> createOrganization(CreateOrganizationRequest request)
        {
            request.UserId = CurrentUser.UserId;
            return Success(await mediator.Send(request));
        }

        [HttpDelete]
        public QzResponse<string> DeleteOrganization([Range(1, double.MaxValue)] long Id)
        {
            return Success($"deleted");
        }

        [HttpGet]
        public async Task<QzResponse<ListOrgResponse>> listOrganizations()
        {
            var res = await mediator.Send(new ListOrgCommand { UserId = CurrentUser.UserId });
            return Success(res);
        }

    }
}
