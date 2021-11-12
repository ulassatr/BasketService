using System;
using MediatR;

namespace BasketService.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}