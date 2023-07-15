using Application.Features.Clientes.Commands.AddArticleToClient;
using Application.Features.Clientes.Commands.AddClient;
using Application.Features.Clientes.Commands.Authentication;
using Application.Features.Clientes.Commands.DeleteClient;
using Application.Features.Clientes.Commands.UpdateClient;
using Application.Features.Clientes.Queries.GetClientInfo;
using Application.Features.Tiendas.Commands.AddArticleToStore;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : BaseController
    {
        public ClientesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{ClienteID}")]
        public async Task<ActionResult<ClientInfoDto>> Get([FromRoute] GetClientInfoQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AddClientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateClientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{ClienteID}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete([FromRoute] DeleteClientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("AddArticle")]
        public async Task<ActionResult<BaseCommandResponse>> AddArticle([FromBody] AddArticleToClientCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthenticateClientCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
