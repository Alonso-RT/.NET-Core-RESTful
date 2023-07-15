using Application.Features.Articulos.Commands.AddArticle;
using Application.Features.Articulos.Commands.DeleteArticle;
using Application.Features.Articulos.Commands.UpdateArticle;
using Application.Features.Articulos.Queries.GetAllArticles;
using Application.Features.Articulos.Queries.GetArticlesByStore;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : BaseController
    {
        public ArticulosController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<GetArticlesByStoreDto>>> Get()
        {
            return Ok(await mediator.Send(new GetAllArticlesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] AddArticleCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateArticleCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{ArticuloID}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete([FromRoute] DeleteArticleCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
