using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;
using System.Linq;

namespace Pazar.Ads.Models
{
    public class CategoryDetailsVm : IMapFrom<Category>
    {
        public string Name { get; private set; }

        public string ImageUrl { get; set; }

        public int TotalAds { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                  .CreateMap<Category, CategoryDetailsVm>()
                     .ForMember(c => c.TotalAds, cfg => cfg
                       .MapFrom(c => c.Ads.Count()));
    }
}
