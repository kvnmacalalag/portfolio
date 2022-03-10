using System;

namespace Portfolio.Domain.Common
{
    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}