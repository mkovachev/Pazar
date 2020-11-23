using FluentValidation;
using Pazar.Ads.Data.Models;

namespace Pazar.Ads.Features.Ads.Commands
{
    using static Data.DataConstants.Ads;

    public class AdValidator : AbstractValidator<Ad>
    {
        public AdValidator()
        {
            RuleFor(ad => ad.Title)
                .Length(TitleMinLength, TitleMaxLength)
                .NotEmpty();

            RuleFor(ad => ad.Price)
                          .ScalePrecision(2, 2)
                          .InclusiveBetween(MinPrice, MaxPrice)
                          .NotEmpty();

            RuleFor(ad => ad.Description)
                .Length(DescriptionMinLength, DescriptionMaxLength)
                .NotEmpty();
        }
    }
}
