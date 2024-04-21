using MediatR;

namespace Qz.Application.Base.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}