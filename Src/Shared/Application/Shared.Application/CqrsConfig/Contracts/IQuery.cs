using DispatchR.Abstractions.Send;

namespace Shared.Application.CqrsConfig.Contracts;

public interface IQuery<TRequest, TResponse> : IRequest<TRequest, TResponse> 
    where TRequest : class { }