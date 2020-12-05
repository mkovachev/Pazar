using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;

namespace Pazar.Ads.Models
{
    public class CategoryVm : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        public void Mapping(Profile mapper)
            => mapper.CreateMap<Category, CategoryVm>()
                     .ReverseMap();
    }
}
