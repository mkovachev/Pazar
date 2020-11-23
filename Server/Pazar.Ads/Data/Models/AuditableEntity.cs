using System;

namespace Pazar.Ads.Data.Models
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public string DeleteBy { get; set; }
    }
}
