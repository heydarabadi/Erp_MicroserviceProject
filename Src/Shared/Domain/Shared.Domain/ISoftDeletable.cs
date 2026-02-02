namespace Shared.Domain;

internal interface ISoftDeletable
{
    bool IsDeleted { get; }
    DateTime? DeletedAtUtc { get; }
    void Delete();
    void UndoDelete();
}