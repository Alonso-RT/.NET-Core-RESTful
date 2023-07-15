using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetAllArticles
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticlesListDto>>
    {
        private readonly IArticuloRepository articuloRepository;
        private readonly IMapper mapper;

        public GetAllArticlesQueryHandler(IArticuloRepository articuloRepository, IMapper mapper)
        {
            this.articuloRepository = articuloRepository;
            this.mapper = mapper;
        }

        public async Task<List<ArticlesListDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var items = await articuloRepository.GetAll();

            return mapper.Map<List<ArticlesListDto>>(items);    
        }
    }
}
