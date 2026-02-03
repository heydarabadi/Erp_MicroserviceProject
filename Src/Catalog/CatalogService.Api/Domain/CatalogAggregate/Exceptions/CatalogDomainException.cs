using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Exceptions;

public class CatalogDomainException : DomainException
{
    public CatalogDomainException(string message, string code, string? details = null) : base(message, code, details)
    {
    }

    public CatalogDomainException(string message) : base(message, "CatalogError")
    {
    }
}