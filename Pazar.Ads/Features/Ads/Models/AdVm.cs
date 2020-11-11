﻿using Pazar.Ads.Data.Models;
using Pazar.Ads.Mappings;
using System.Collections.Generic;

namespace Pazar.Ads.Features.Ads.Models
{
    public class AdVm : IMapFrom<Ad>
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public ICollection<Image> Images { get; }
    }
}