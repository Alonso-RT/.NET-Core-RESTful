using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetArticlesByStore
{
    public class GetArticlesByStoreQuery : IRequest<List<GetArticlesByStoreDto>>
    {
        public int TiendaID { get; set; }
    }
}
