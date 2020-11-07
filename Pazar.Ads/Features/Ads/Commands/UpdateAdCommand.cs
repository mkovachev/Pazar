using MediatR;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Data.Models;
using Pazar.Ads.Features.Ads.Models;
using Pazar.Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Ads.Commands
{
    public class UpdateAdCommand : AdVm, IRequest
    {
        public int Id { get; set; }

        public class UpdateAdCommandHandler : IRequestHandler<UpdateAdCommand>
        {
            private readonly PazarDbContext db;

            public UpdateAdCommandHandler(PazarDbContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
            {
                var ad = await this.db.Ads.FindAsync(request.Id, cancellationToken);

                if (ad == null)
                {
                    throw new NotFoundException(nameof(Ad), request.Id);
                }

                this.db.Entry(ad).State = EntityState.Modified;

                await this.db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
