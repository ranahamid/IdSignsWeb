using System;

namespace Core.Interfaces
{
    public interface IAuditFields
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
    }
}
