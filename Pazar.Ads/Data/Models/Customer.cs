using System.Collections.Generic;

namespace Pazar.Ads.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<Ad> Ads { get; set; } = new List<Ad>();
    }
}
