using Application.Contracts;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetClientInfo
{
    internal class GetClientInfoQueryHandler : IRequestHandler<GetClientInfoQuery, ClientInfoDto>
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IMapper mapper;

        public GetClientInfoQueryHandler(IClientesRepository clientesRepository, IMapper mapper)
        {
            this.clientesRepository = clientesRepository;
            this.mapper = mapper;
        }

        public async Task<ClientInfoDto> Handle(GetClientInfoQuery request, CancellationToken cancellationToken)
        {
            var client = await clientesRepository.Get(request.ClienteID);
            if(client == null) { throw new NotFoundException("Cliente", request.ClienteID); }

            return mapper.Map<ClientInfoDto>(client);
        }
    }
}
