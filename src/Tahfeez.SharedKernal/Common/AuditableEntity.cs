namespace Tahfeez.SharedKernal.Common;

public abstract class AuditableEntity : BaseEntity
{
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; protected set; }

    public void SoftDelete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
