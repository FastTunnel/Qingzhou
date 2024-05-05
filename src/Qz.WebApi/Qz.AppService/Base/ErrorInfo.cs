using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Base
{
    public class ErrorInfo
    {
        public ErrorInfo(string title, Dictionary<string, string[]>? errors, string traceId)
        {
            Title = title;
            Errors = errors;
            TraceId = traceId;
        }

        public string Title { get; set; }

        public Dictionary<string, string[]>? Errors { get; set; }

        public string TraceId { get; set; }
    }
}
