using AutoMapper;
using Pazar.Ads.Data.Models;

namespace Pazar.Ads.Models
{
    public class MyAdsVm : AdVm
    {
        public bool IsActive { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Ad, MyAdsVm>()
                .IncludeBase<Ad, AdVm>();
        //.ForMember(a => a.Images, cfg => cfg
        //    .MapFrom(a => a.Images.ToList()))

    }
}
