namespace Shared.Domain;

internal interface IAuditable
{
    DateTime CreatedAtUtc { get; }
    DateTime? ModifiedAtUtc { get; }
    string? CreatedBy { get; }
}