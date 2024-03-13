using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Base
{
    public class QzResponse
    {
        public bool Success { get; set; }

        public ErrorCode Code { get; set; } = 0;

        public object? Data { get; set; }

        public string? message { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
    }
}
