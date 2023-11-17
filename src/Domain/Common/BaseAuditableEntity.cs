namespace LS.Store.Domain.Common;

public abstract class BaseAuditableEntity<IdType> : BaseEntity<IdType>, IBaseAuditableEntity where IdType : struct
{
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
