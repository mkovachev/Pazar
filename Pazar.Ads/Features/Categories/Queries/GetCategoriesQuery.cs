using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Features.Categories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pazar.Ads.Features.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryVm>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryVm>>
        {
            private readonly PazarDbContext db;
            private readonly IMapper mapper;
            public GetCategoriesQueryHandler(PazarDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<CategoryVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
                    => await this.db.Categories
                            .OrderBy(c => c.Name)
                            .ProjectTo<CategoryVm>(this.mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
        }
    }
}
