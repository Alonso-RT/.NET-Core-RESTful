using Application.Common;
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

namespace Application.Features.Clientes.Commands.AddClient
{
    internal class AddClientCommandHandler : IRequestHandler<AddClientCommand, BaseCommandResponse>
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IMapper mapper;

        public AddClientCommandHandler(IClientesRepository clientesRepository, IMapper mapper)
        {
            this.clientesRepository = clientesRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var vResult = await new AddClientCommandValidator().ValidateAsync(request);
            if (!vResult.IsValid)
            { throw new BadRequestException("Validation result", vResult); }

            if (await clientesRepository.GetUserByName(request.NombreUsuario)  != null) 
            { throw new BadRequestException($"Ya existe un cliente con el nombre {request.NombreUsuario}"); }

            var cliente = new tblCliente();
            mapper.Map(request, cliente);

            cliente.Contrasena = Security.SHA256(cliente.Contrasena);

            cliente = await clientesRepository.Add(cliente);

            return new BaseCommandResponse
            {
                ID = cliente.ClienteID,
                Success = true,
                Message = "Usuario creado correctamente!"
            };
        }
    }
}
