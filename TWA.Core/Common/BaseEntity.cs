using System;

namespace TWA.Core.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // SQL Server Identity
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}