using Pazar.Ads.Data.Models;
using Pazar.Ads.Mappings;

namespace Pazar.Ads.Features.Categories.Models
{
    public class CategoryVm : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}
