using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<BaseCommandResponse>
    {
        public int ArticuloID { get; set; }
    }
}
