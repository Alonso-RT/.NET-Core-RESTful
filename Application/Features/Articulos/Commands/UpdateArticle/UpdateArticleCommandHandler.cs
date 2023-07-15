using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.UpdateArticle
{
    internal class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, BaseCommandResponse>
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IMapper mapper;

        public UpdateArticleCommandHandler(IArticuloRepository articuloRepository, IMapper mapper)
        {
            this.articuloRepository = articuloRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var vResult = await new UpdateArticleCommandValidator().ValidateAsync(request);
            if( !vResult.IsValid ) { throw new BadRequestException("Validation", vResult); }

            var articulo = await articuloRepository.Get(request.ArticuloID);
            if(articulo == null) { throw new NotFoundException("Articulo", request.ArticuloID); }

            if(articulo.Codigo != request.Codigo && await articuloRepository.GetByCode(request.Codigo) != null)
            { throw new BadRequestException($"Ya existe otro articulo con el codigo: {request.Codigo}"); }

            mapper.Map(request, articulo);

            await articuloRepository.Update(articulo);

            return new BaseCommandResponse
            {
                ID = articulo.ArticuloID,
                Success = true,
                Message = "Articulo actualizado correctamente!"
            };
        }
    }
}
