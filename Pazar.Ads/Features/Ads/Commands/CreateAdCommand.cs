using MediatR;
using Pazar.Ads.Data;
using Pazar.Ads.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Ads.Commands
{
    public class CreateAdCommand : AdDto, IRequest<int>
    {
        public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand, int>
        {
            private readonly PazarDbContext db;
            public CreateAdCommandHandler(PazarDbContext db)
            {
                this.db = db;
            }
            public async Task<int> Handle(CreateAdCommand request, CancellationToken cancellationToken)
            {

                var ad = new Ad
                {
                    Title = request.Title,
                    Price = request.Price,
                    Description = request.Description,
                    IsActive = true,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId
                };

                await this.db.Ads.AddAsync(ad, cancellationToken);

                await this.db.SaveChangesAsync(cancellationToken);

                return ad.Id;
            }
        }
    }
}
