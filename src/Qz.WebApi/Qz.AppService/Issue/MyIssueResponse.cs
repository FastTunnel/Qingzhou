using Qz.Domain.Workitems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Issue
{
    public class MyIssueResponse
    {
        public IEnumerable<Workitem> Issues { get; internal set; }
    }
}
