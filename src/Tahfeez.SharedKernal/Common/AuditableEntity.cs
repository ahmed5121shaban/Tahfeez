using Tahfeez.SharedKernal.Interfaces;

namespace Tahfeez.SharedKernal.Common;

public abstract class AuditableEntity : BaseEntity ,ISoftDeletable
{
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
