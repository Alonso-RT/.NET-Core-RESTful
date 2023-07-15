using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Queries.GetStoreList
{
    public class GetStoreListQuery : IRequest<List<StoreListDto>>
    {
    }
}
