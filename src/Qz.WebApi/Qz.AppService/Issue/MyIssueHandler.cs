using Qz.Application.Base;
using Qz.Application.Base.Commands;
using Qz.Domain.Workitems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Issue
{
    public class MyIssueHandler : ICommandHandler<MyIssueCommand, MyIssueResponse>
    {
        IWorkitemRepository issueRepository;

        public MyIssueHandler(IWorkitemRepository issueRepository)
        {
            this.issueRepository = issueRepository;
        }

        public Task<MyIssueResponse> Handle(MyIssueCommand request, CancellationToken cancellationToken)
        {
            var res = issueRepository.MyIssue(request.OrgId, request.UserId);
            return Task.FromResult(new MyIssueResponse
            {
                Issues = res
            });
        }
    }
}
