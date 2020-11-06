using Pazar.Ads.Data.Models;
using System.Collections.Generic;

namespace Pazar.Ads.Data.Interfaces
{
    public interface IInitialCategories
    {
        IEnumerable<Category> GetInitialCategories();
    }
}
