using Microsoft.AspNetCore.Mvc;

namespace Pazar.Ads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";
    }
}
