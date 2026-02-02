using DispatchR.Abstractions.Send;

namespace Shared.Application.CqrsConfig.Contracts;

public interface ICommandHandler<TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse> 
    where TCommand : class, ICommand<TCommand, TResponse> { }