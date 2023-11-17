
namespace LS.Store.Domain.Common;

public interface IBaseEntity
{
    IReadOnlyCollection<BaseEvent> DomainEvents { get; }

    void AddDomainEvent(BaseEvent domainEvent);
    void ClearDomainEvents();
    void RemoveDomainEvent(BaseEvent domainEvent);
}