using Shared.Application.CqrsConfig;

namespace Warehouse.Api.Application.WarehouseAggregate.Commands.Create;

public sealed class CreateWarehouseHandler : ICommandHandler<CreateWarehouseCommand, bool>
{
    public bool Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}