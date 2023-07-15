using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Commands.AddArticleToStore
{
    public class AddArticleToStoreCommand : IRequest<BaseCommandResponse>
    {
        public int TiendaID { get; set; }
        public int ArticuloID { get; set; }
    }
}
