using FluentValidation;

namespace Pazar.Ads.Features.Ads.Commands
{
    using static Data.DataConstants.Ads;
    public class UpdateAdCommandValidator : AbstractValidator<UpdateAdCommand>
    {
        public UpdateAdCommandValidator()
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
