using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public ICollection<Image> Images = new List<Image>();
    }
}
