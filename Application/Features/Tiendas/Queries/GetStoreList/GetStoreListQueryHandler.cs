using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Queries.GetStoreList
{
    internal class GetStoreListQueryHandler : IRequestHandler<GetStoreListQuery, List<StoreListDto>>
    {
        private readonly ITiendaRepository tiendaRepository;
        private readonly IMapper mapper;

        public GetStoreListQueryHandler(ITiendaRepository tiendaRepository, IMapper mapper)
        {
            this.tiendaRepository = tiendaRepository;
            this.mapper = mapper;
        }

        public async Task<List<StoreListDto>> Handle(GetStoreListQuery request, CancellationToken cancellationToken)
        {
            var storeList = await tiendaRepository.GetAll();
            return mapper.Map<List<StoreListDto>>(storeList);
        }
    }
}
