using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Pazar.Ads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        private IMediator mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();
    }
}
