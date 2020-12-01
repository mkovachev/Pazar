using Pazar.Ads.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pazar.Ads.Models
{
    using static Data.DataConstants.Ads;

    public class AdIm
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range((double)MinPrice, (double)MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }


        [Required]
        public string Category { get; set; }

        //public string UserId { get; set; }

        [Required]
        [Url]
        public ICollection<Image> Images { get; }
    }
}
