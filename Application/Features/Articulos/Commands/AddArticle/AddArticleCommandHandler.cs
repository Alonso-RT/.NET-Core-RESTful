using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.AddArticle
{
    internal class AddArticleCommandHandler : IRequestHandler<AddArticleCommand, BaseCommandResponse>
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IMapper mapper;

        public AddArticleCommandHandler(IArticuloRepository articuloRepository, IMapper mapper)
        {
            this.articuloRepository = articuloRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            if (await articuloRepository.GetByCode(request.Codigo) != null)
            { throw new BadRequestException($"Ya existe un articulo con el código: {request.Codigo}"); }

            var article = new tblArticulo();
            mapper.Map(request, article);

            article = await articuloRepository.Add(article);

            return new BaseCommandResponse
            {
                ID = article.ArticuloID,
                Success = true,
                Message = "Articulo creado correctamente!"
            };
        }
    }
}
