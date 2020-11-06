using MediatR;
using Pazar.Ads.Data;
using Pazar.Ads.Data.Models;
using Pazar.Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Ads.Commands
{
    public class DeleteAdCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAdCommandHandler : IRequestHandler<DeleteAdCommand>
        {

            private readonly PazarDbContext db;
            public DeleteAdCommandHandler(PazarDbContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
            {
                var ad = await this.db.Ads.FindAsync(request.Id);

                if (ad == null)
                {
                    throw new NotFoundException(nameof(Ad), request.Id);
                }

                this.db.Ads.Remove(ad);

                await this.db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
