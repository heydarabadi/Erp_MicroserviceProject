using CatalogService.Api.Domain.CatalogAggregate.Exceptions;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Exceptions;

public class NameRequiredException() : CatalogDomainException("Name is required Exception");