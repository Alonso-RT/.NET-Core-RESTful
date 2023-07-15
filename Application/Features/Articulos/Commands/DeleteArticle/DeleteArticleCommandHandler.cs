using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.DeleteArticle
{
    internal class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, BaseCommandResponse>
    {
        private readonly IArticuloRepository articuloRepository;

        public DeleteArticleCommandHandler(IArticuloRepository articuloRepository)
        {
            this.articuloRepository = articuloRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var articulo = await articuloRepository.Get(request.ArticuloID);
            if (articulo == null) { throw new NotFoundException("Articulo", request.ArticuloID); }

            await articuloRepository.Delete(articulo);

            return new BaseCommandResponse
            {
                ID = 0,
                Success = true,
                Message = "Articulo eliminado correctamente!"
            };
        }
    }
}
