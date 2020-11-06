using System.Collections.Generic;

namespace Pazar.Ads.Features.Ads.Models
{
    public class AdsVm
    {
        public string Title { get; set; }
        public IList<AdDto> AllAds { get; set; }
    }
}
