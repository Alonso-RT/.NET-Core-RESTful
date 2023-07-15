using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetClientInfo
{
    public class GetClientInfoQuery : IRequest<ClientInfoDto>
    {
        public int ClienteID { get; set; }
    }
}
