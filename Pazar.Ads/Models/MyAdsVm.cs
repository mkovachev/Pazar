using AutoMapper;
using Pazar.Ads.Data.Models;
using System.Linq;

namespace Pazar.Ads.Models
{
    public class MyAdsVm : AdVm
    {
        public bool IsActive { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Ad, MyAdsVm>()
                .ForMember(a => a.Images, cfg => cfg
                    .MapFrom(a => a.Images.ToList()))
                .IncludeBase<Ad, AdVm>();

    }
}
