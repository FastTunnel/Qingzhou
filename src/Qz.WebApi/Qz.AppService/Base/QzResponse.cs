using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Base
{
    public class QzResponse<T>
    {
        /// <summary>
        /// 接口成功失败
        /// </summary>
        public required bool Success { get; set; }

        public ErrorCode Code { get; set; } = 0;

        public T? Data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string? Message { get; set; }

        public long Message1 { get; set; }

        public required string TraceId { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
    }
}
