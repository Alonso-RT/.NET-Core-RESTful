using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<BaseCommandResponse>
    {
        public int ClienteID { get; set; }
    }
}
