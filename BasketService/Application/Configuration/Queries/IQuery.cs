using MediatR;

namespace BasketService.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}