using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.AddArticleToClient
{
    internal class AddArticleToClientCommandHandler : IRequestHandler<AddArticleToClientCommand, BaseCommandResponse>
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IArticuloRepository articuloRepository;

        public AddArticleToClientCommandHandler(IClientesRepository clientesRepository, IArticuloRepository articuloRepository)
        {
            this.clientesRepository = clientesRepository;
            this.articuloRepository = articuloRepository;
        }

        public async Task<BaseCommandResponse> Handle(AddArticleToClientCommand request, CancellationToken cancellationToken)
        {
            var client = await clientesRepository.GetUserByName(request.UserName);
            if (client == null)
            { throw new NotFoundException("Cliente", request.UserName); }

            foreach (var item in request.CartItems)
            {
                var articulo = await articuloRepository.Get(item.Product.ArticuloID);
                if (articulo == null) { throw new NotFoundException("Articulo", item.Product.ArticuloID); }


                if (articulo.Stock < item.Quantity)
                {
                    throw new BadRequestException($"No se puede completar la compra debido a falta de stock del articulo {articulo.Codigo}");
                }
                articulo.Stock -= item.Quantity;

                await articuloRepository.Update(articulo);
                await clientesRepository.AddArticle(client, articulo, item.Quantity);
            }

            

            return new BaseCommandResponse
            {
                ID = 0,
                Success = true,
                Message = "Compra realizada correctamente!"
            };
        }
    }
}
