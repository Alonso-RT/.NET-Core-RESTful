using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Commands.AddStore
{
    public class AddStoreCommand : IRequest<BaseCommandResponse>
    {
        public string Sucursal { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
