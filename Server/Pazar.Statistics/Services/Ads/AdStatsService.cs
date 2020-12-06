﻿using Pazar.Statistics.Data;
using Pazar.Statistics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Ads
{
    public class AdStatsService : IAdStatsService
    {
        private readonly StatisticsDbContext db;
        public AdStatsService(StatisticsDbContext db)
        {
            this.db = db;
        }
        public async Task<int> TotalViews(int id)
            => await this.db.Ads.CountAsync(ad => ad.AdId == id);

        public async Task<IEnumerable<AdVm>> TotalViews(IEnumerable<int> ids)
             => await this.db.Ads
                             .Where(v => ids.Contains(v.AdId))
                             .GroupBy(v => v.AdId)
                             .Select(gr => new AdVm
                             {
                                 Id = gr.Key,
                                 TotalViews = gr.Count()
                             })
                             .ToListAsync();
    }
}
