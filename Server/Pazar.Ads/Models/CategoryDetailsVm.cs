using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Ads.Mappings;
using System.Linq;

namespace Pazar.Ads.Models
{
    public class CategoryDetailsVm : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int TotalAds { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryVm>()
                .ForMember(c => c.TotalAds, cfg => cfg
                    .MapFrom(c => c.Ads.ToList()));
    }
}
