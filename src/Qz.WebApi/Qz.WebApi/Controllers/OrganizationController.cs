using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Orgs.CreateOrganization;
using Qz.Application.Orgs.ListOrg;
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
        public async Task<QzResponse<CreateOrganizationResponse>> CreateOrganization(CreateOrganizationRequest request)
        {
            request.UserId = CurrentUser.UserId;
            var res = await mediator.Send(request);
            return Success(res);
        }

        [HttpDelete]
        public QzResponse<string> DeleteOrganization([Range(1, double.MaxValue)] long Id)
        {
            return Success($"deleted");
        }

        [HttpGet]
        public async Task<QzResponse<ListOrgResponse>> ListOrganizations()
        {
            var res = await mediator.Send(new ListOrgCommand { UserId = CurrentUser.UserId });
            return Success(res);
        }

    }
}
