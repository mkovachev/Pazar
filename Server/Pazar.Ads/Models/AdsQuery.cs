using Pazar.Ads.Data.Models;
using System.Collections.Generic;

namespace Pazar.Ads.Models
{
    public class AdsQuery
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }

        public ICollection<Image> Images { get; }

        public string SortBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; } = 1;
    }
}
