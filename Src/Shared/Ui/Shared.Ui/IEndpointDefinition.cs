using Microsoft.AspNetCore.Routing;

namespace Shared.Ui;

public interface IEndpointDefinition
{
    void DefineEndpoints(IEndpointRouteBuilder app);
}