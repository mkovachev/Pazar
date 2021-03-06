﻿using AutoMapper;
using Pazar.Ads.Data.Models;
using Pazar.Core.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Pazar.Ads.Models
{
    using static Data.DataConstants.Ads;
    using static Data.DataConstants.Image;

    public class AdCreateIm : IMapTo<Ad>
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range((double)MinPrice, (double)MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Url]
        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<AdCreateIm, Ad>().ReverseMap();

    }
}
