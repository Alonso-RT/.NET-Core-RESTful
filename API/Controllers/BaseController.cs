using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        internal readonly IMediator mediator;
        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
