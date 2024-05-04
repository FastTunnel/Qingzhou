using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Projects.CreateProject;
using Qz.Application.Projects.ListProject;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class ProjectsController : BaseController
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IMediator mediator;

        public ProjectsController(ILogger<ProjectsController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet("listProjects")]
        public async Task<QzResponse<ListProjectResponse>> ListProjects(long organizationId, ListProjectRequest request)
        {
            request.OrganizationId = organizationId;
            return Success(await mediator.Send(request));
        }

        [HttpPost("createProject")]
        public async Task<QzResponse<CreateProjectResponse>> CreateProject(long organizationId, CreateProjectRequest request)
        {
            request.OrganizationId = organizationId;
            request.CreatedBy = CurrentUser.UserId;

            return Success(await mediator.Send(request));
        }

        // DELETE /organization/{organizationId}/projects/delete
        // POST /organization/{organizationId}/projects/{projectId}/updateMember
        // GET /organization/{organizationId}/project/{projectId}
        // GET /organization/{organizationId}/projects/listTemplates
    }
}
