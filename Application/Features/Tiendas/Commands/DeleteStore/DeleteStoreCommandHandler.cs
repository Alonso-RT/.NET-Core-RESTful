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

namespace Application.Features.Tiendas.Commands.DeleteStore
{
    internal class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, BaseCommandResponse>
    {
        private readonly ITiendaRepository tiendaRepository;
        private readonly IMapper mapper;

        public DeleteStoreCommandHandler(ITiendaRepository tiendaRepository, IMapper mapper)
        {
            this.tiendaRepository = tiendaRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var tienda = await tiendaRepository.Get(request.TiendaID);
            if(tienda == null) { throw new NotFoundException("Tienda", request.TiendaID); }

            await tiendaRepository.Delete(tienda);

            return new BaseCommandResponse
            {
                ID = 0,
                Success = true,
                Message = "Tienda eliminada correctamente!"
            };
        }
    }
}
