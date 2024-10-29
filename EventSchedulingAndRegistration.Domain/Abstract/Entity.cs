using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Domain.Abstract
{
    public abstract class Entity: IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
