using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Features.Ads.Models;
using Pazar.Ads.Features.Categories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Ads.Queries
{
    public class GetAdsPerCategory : CategoryVm, IRequest<IEnumerable<AdVm>>
    {
        public class GetAdsPerCategoryHandler : IRequestHandler<GetAdsPerCategory, IEnumerable<AdVm>>
        {
            private readonly PazarDbContext db;
            private readonly IMapper mapper;
            public GetAdsPerCategoryHandler(PazarDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<AdVm>> Handle(GetAdsPerCategory request, CancellationToken cancellationToken)
                => await this.db.Categories
                            .Where(c => c.Id == request.Id)
                            .Select(c => c.Ads
                                            .Where(ad => ad.IsActive)
                                            .OrderBy(ad => ad.Title))
                            .ProjectTo<AdVm>(this.mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
        }
    }
}
