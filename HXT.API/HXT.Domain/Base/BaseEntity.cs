using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HXT.Domain.Base
{
    public interface IAuditEntity
    {
        Guid? LastSavedUser { get; set; }

        DateTime? LastSavedTime { get; set; }

        Guid? CreatedUser { get; set; }

        DateTime? CreatedTime { get; set; }

        bool IsDeleted { get; set; }
    }

    [Index(nameof(IsDeleted), IsUnique = false)]
    public abstract class BaseEntity : IAuditEntity
    {
        [Key]
        public Guid Id { get; set; } = new Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator().Next(null);

        public Guid? LastSavedUser { get; set; }

        public DateTime? LastSavedTime { get; set; }

        public Guid? CreatedUser { get; set; }

        public DateTime? CreatedTime { get; set; }
   
        public bool IsDeleted { get; set; }
    }
}
