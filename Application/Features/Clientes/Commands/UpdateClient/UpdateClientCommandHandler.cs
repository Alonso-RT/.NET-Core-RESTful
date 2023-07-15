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

namespace Application.Features.Clientes.Commands.UpdateClient
{
    internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, BaseCommandResponse>
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IMapper mapper;

        public UpdateClientCommandHandler(IClientesRepository clientesRepository, IMapper mapper)
        {
            this.clientesRepository = clientesRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var vResult = await new UpdateClientCommandValidator().ValidateAsync(request, cancellationToken);
            if(!vResult.IsValid)
            { throw new BadRequestException("Validation", vResult); }

            var client = await clientesRepository.Get(request.ClienteID);
            if (client == null) 
            { throw new NotFoundException("Cliente", request.ClienteID); }

            mapper.Map(request, client);

            await clientesRepository.Update(client);

            return new BaseCommandResponse
            {
                ID = client.ClienteID,
                Success = true,
                Message = "Cliente actualizado correctamente!"
            };
        }
    }
}
