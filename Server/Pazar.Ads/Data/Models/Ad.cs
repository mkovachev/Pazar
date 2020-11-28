using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Ad : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string UserId { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
