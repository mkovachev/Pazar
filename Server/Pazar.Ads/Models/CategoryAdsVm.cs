using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;
using System.Collections.Generic;

namespace Pazar.Ads.Models
{
    public class CategoryAdsVm : IMapFrom<Category>
    {
        public string ImageUrl { get; set; }

        public ICollection<Ad> Ads { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                 .CreateMap<Category, CategoryAdsVm>()
                 .ForMember(c => c.Ads, cfg => cfg
                     .MapFrom(c => c.Ads))
                 .ReverseMap();
    }
}
