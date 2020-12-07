﻿using Pazar.Statistics.Models;
using Pazar.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Pazar.Core.Controllers;

namespace Pazar.Statistics.Controllers
{
    public class AdsStatisticsController : ApiController
    {
        private readonly IStatisticsService adsStatistics;

        public AdsStatisticsController(IStatisticsService adsStatistics)
        {
            this.adsStatistics = adsStatistics;
        }

        [HttpGet]
        public async Task<AdsStatisticsVm> AdsOverview()
            => await this.adsStatistics.AdsOverview();
    }
}