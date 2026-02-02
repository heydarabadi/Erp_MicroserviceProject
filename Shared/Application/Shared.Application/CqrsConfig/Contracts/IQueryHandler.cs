using DispatchR.Abstractions.Send;

namespace Shared.Application.CqrsConfig.Contracts;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> 
    where TQuery : class, IQuery<TQuery, TResponse> { }