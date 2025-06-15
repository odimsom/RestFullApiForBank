namespace RestFullApiForBank.Core.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LatModifiedBy { get; set; }
        public DateTime? LastModified { get; set;  }
    }
}
