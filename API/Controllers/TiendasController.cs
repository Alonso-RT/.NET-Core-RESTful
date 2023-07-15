using Application.Features.Articulos.Queries.GetArticlesByStore;
using Application.Features.Tiendas.Commands.AddArticleToStore;
using Application.Features.Tiendas.Commands.AddStore;
using Application.Features.Tiendas.Commands.DeleteStore;
using Application.Features.Tiendas.Commands.UpdateStore;
using Application.Features.Tiendas.Queries.GetStoreList;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : BaseController
    {
        public TiendasController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreListDto>>> GetAll()
        {
            return Ok(await mediator.Send(new GetStoreListQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AddStoreCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateStoreCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{TiendaID}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete([FromRoute] DeleteStoreCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("AddArticle")]
        public async Task<ActionResult<BaseCommandResponse>> AddArticle([FromQuery] AddArticleToStoreCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("{TiendaID}/Articles")]
        public async Task<ActionResult<List<GetArticlesByStoreDto>>> Get([FromRoute] GetArticlesByStoreQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}
