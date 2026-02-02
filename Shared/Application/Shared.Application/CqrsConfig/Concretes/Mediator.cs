using DispatchR;
using DispatchR.Abstractions.Send;
using IMediator = Shared.Application.CqrsConfig.Contracts.IMediator;

namespace Shared.Application.CqrsConfig;

internal class Mediator(DispatchR.IMediator dispatcher) : IMediator
{
    public TResponse Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) 
        where TRequest : class, IRequest<TRequest, TResponse>
    {
        // ارجاع مستقیم به متد Send در IMediator
        return dispatcher.Send<TRequest, TResponse>(request, cancellationToken);
    }
}