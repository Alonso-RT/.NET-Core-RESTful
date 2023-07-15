using Application.Models;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.AddArticleToClient
{
    public class AddArticleToClientCommand : IRequest<BaseCommandResponse>
    {
        public string UserName { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public tblArticulo Product { get; set; } = new tblArticulo();
        public int Quantity { get; set; }
    }
}
