﻿using Pazar.Statistics.Data.Models;
using Pazar.Statistics.Models;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<int> AdsOverview();
    }
}
