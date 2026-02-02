namespace Shared.Domain;

public interface IDomainEvent
{
    // تنها فیلد استاندارد برای یک ایونت دامنه
    DateTime OccurredOn { get; }
}