using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetArticlesByStore
{
    internal class GetArticlesByStoreQueryHandler : IRequestHandler<GetArticlesByStoreQuery, List<GetArticlesByStoreDto>>
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IMapper mapper;

        public GetArticlesByStoreQueryHandler(IArticuloRepository articuloRepository, IMapper mapper)
        {
            this.articuloRepository = articuloRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetArticlesByStoreDto>> Handle(GetArticlesByStoreQuery request, CancellationToken cancellationToken)
        {
            var list = await articuloRepository.GetByStoreID(request.TiendaID);

            return mapper.Map<List<GetArticlesByStoreDto>>(list);   
        }
    }
}
