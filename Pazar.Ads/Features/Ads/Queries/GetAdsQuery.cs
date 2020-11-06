using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Features.Ads.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Ads.Queries
{
    public class GetAdsQuery : IRequest<IEnumerable<AdsVm>>
    {
        public class GetAdsQueryHandler : IRequestHandler<GetAdsQuery, IEnumerable<AdsVm>>
        {
            private readonly PazarDbContext db;
            private readonly IMapper mapper;

            public GetAdsQueryHandler(PazarDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<AdsVm>> Handle(GetAdsQuery request, CancellationToken cancellationToken)
                  => await this.db.Ads
                            .OrderBy(ad => ad.Title)
                            .ProjectTo<AdsVm>(mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

        }
    }
}
