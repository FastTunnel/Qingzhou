using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Issue
{
    public class MyIssueResponse
    {
        public IEnumerable<Domain.Issues.Issue> Issues { get; internal set; }
    }
}
