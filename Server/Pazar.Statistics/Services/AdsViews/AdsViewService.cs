using Microsoft.EntityFrameworkCore;
using Pazar.Statistics.Data;
using Pazar.Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.AdsViews
{
    public class AdsViewService : IAdsViewService
    {
        private readonly StatisticsDbContext db;
        public AdsViewService(StatisticsDbContext db)
        {
            this.db = db;
        }
        public async Task<int> TotalViews(int id)
            => await this.db.AdViews.CountAsync(ad => ad.AdId == id);

        public async Task<IEnumerable<AdsVm>> TotalViews(IEnumerable<int> ids)
             => await this.db.AdViews
                             .Where(v => ids.Contains(v.AdId))
                             .GroupBy(v => v.AdId)
                             .Select(gr => new AdsVm
                             {
                                 Id = gr.Key,
                                 TotalViews = gr.Count()
                             })
                             .ToListAsync();
    }
}
