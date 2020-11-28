using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public string Image { get; set; }

        public ICollection<Ad> Ads { get; } = new List<Ad>();
    }
}
