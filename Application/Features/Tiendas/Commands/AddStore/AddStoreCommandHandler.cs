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

namespace Application.Features.Tiendas.Commands.AddStore
{
    internal class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, BaseCommandResponse>
    {
        private readonly ITiendaRepository tiendaRepository;
        private readonly IMapper mapper;

        public AddStoreCommandHandler(ITiendaRepository tiendaRepository, IMapper mapper)
        {
            this.tiendaRepository = tiendaRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var vResult = await new AddStoreCommandValidator().ValidateAsync(request, cancellationToken);
            if(!vResult.IsValid) 
            { throw new BadRequestException("Validation", vResult); }

            if (await tiendaRepository.GetStoreByName(request.Sucursal) != null)
            { throw new BadRequestException($"Ya existe una sucursal con el nombre: {request.Sucursal}"); }

            var tienda = new tblTienda();

            mapper.Map(request, tienda);

            tienda = await tiendaRepository.Add(tienda);

            return new BaseCommandResponse
            {
                ID = tienda.TiendaID,
                Success = true,
                Message = "Tienda creada correctamente!"
            };
        }
    }
}
