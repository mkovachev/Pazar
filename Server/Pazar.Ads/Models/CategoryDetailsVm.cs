using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;
using System.Collections.Generic;
using System.Linq;

namespace Pazar.Ads.Models
{
    public class CategoryDetailsVm : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public List<Ad> Ads { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryDetailsVm>()
                .ForMember(c => c.Ads, cfg => cfg
                    .MapFrom(c => c.Ads.ToList()));
    }
}
