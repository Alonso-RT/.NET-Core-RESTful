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

namespace Application.Features.Tiendas.Commands.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, BaseCommandResponse>
    {
        private readonly ITiendaRepository tiendaRepository;
        private readonly IMapper mapper;

        public UpdateStoreCommandHandler(ITiendaRepository tiendaRepository, IMapper mapper)
        {
            this.tiendaRepository = tiendaRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var vResult = await new UpdateStoreCommandValidator().ValidateAsync(request, cancellationToken);
            if (!vResult.IsValid)
            { throw new BadRequestException("Validation", vResult); }

            var tienda = await tiendaRepository.Get(request.TiendaID);
            if (tienda == null)
            { throw new NotFoundException("Tienda", request.TiendaID); }

            mapper.Map(request, tienda);

            await tiendaRepository.Update(tienda);

            return new BaseCommandResponse
            {
                ID = tienda.TiendaID,
                Success = true,
                Message = "Tienda actualizada correctamente!"
            };
        }
    }
}
