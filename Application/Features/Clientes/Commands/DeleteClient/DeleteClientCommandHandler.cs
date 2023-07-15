using Application.Contracts;
using Application.Exceptions;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.DeleteClient
{
    internal class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, BaseCommandResponse>
    {
        private readonly IClientesRepository clientesRepository;

        public DeleteClientCommandHandler(IClientesRepository clientesRepository)
        {
            this.clientesRepository = clientesRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await clientesRepository.Get(request.ClienteID);
            if (client == null) { throw new NotFoundException("Cliente", request.ClienteID); }

            await clientesRepository.Delete(client);

            return new BaseCommandResponse
            {
                ID = request.ClienteID,
                Success = true,
                Message = "Cliente eliminado correctamente!"
            };
        }
    }
}
