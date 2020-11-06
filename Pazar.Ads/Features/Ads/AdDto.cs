using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Pazar.Ads.Features.Ads
{
    using static Data.DataConstants.Ads;
    using static Pazar.Ads.Data.DataConstants;

    public class AdDto
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMinLength)]
        public string Title { get; private set; }

        [Required]
        [Range((double)MinPrice, (double)MaxPrice)]
        public decimal Price { get; private set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; private set; }

        public bool IsActive { get; private set; } = true;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Image> Images { get; }
    }
}
