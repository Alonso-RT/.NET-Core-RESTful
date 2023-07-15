using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Commands.AddArticleToStore
{
    internal class AddArticleToStoreCommandHandler : IRequestHandler<AddArticleToStoreCommand, BaseCommandResponse>
    {
        private readonly ITiendaRepository tiendaRepository;
        private readonly IArticuloRepository articuloRepository;

        public AddArticleToStoreCommandHandler(ITiendaRepository tiendaRepository, IArticuloRepository articuloRepository)
        {
            this.tiendaRepository = tiendaRepository;
            this.articuloRepository = articuloRepository;
        }

        public async Task<BaseCommandResponse> Handle(AddArticleToStoreCommand request, CancellationToken cancellationToken)
        {
            var articulo = await articuloRepository.Get(request.ArticuloID);
            if (articulo == null) { throw new NotFoundException("Articulo", request.ArticuloID); }

            var tienda = await tiendaRepository.Get(request.TiendaID);
            if (tienda == null)
            { throw new NotFoundException("Tienda", request.TiendaID); }

            await tiendaRepository.AddArticle(tienda, articulo);

            return new BaseCommandResponse
            {
                ID = 0,
                Success = true,
                Message = "Articulo agregado correctamente!"
            };
        }
    }
}
