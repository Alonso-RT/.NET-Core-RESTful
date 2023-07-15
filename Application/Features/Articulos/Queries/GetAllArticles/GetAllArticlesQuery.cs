using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetAllArticles
{
    public class GetAllArticlesQuery : IRequest<List<ArticlesListDto>>
    {
    }
}
