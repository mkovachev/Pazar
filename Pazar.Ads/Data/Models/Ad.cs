using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int UserId { get; set; }

        public ICollection<Image> Images { get; } = new List<Image>();
    }
}
