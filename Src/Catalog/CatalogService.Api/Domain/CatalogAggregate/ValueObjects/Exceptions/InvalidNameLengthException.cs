using CatalogService.Api.Domain.CatalogAggregate.Exceptions;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Exceptions;

public class InvalidNameLengthException() : CatalogDomainException("Name must be in range 3 to 100 ");