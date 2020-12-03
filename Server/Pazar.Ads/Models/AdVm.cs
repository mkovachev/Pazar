using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;

namespace Pazar.Ads.Models
{
    public class AdVm : IMapFrom<Ad>
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string UserId { get; set; }


        public virtual void Mapping(Profile mapper)
           => mapper
               .CreateMap<Ad, AdVm>()
               .ForMember(ad => ad.Category, cfg => cfg
                   .MapFrom(ad => ad.Category.Name));
    }
}
