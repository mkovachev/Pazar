using Pazar.Core.Interfaces;
using System;

namespace Pazar.Ads.Infrastructure
{
    public class DateTimeProvider : IDateTime
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
