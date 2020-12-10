using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
            this.ImageUrl = "https://picsum.photos/200?random=&giud=(Guid.NewGuid())";
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public string ImageUrl { get; set; }

        public ICollection<Ad> Ads { get; set; } = new List<Ad>();
    }
}
