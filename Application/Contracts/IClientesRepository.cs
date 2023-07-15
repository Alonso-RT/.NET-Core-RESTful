using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IClientesRepository : IGenericRepository<tblCliente>
    {
        public Task<tblCliente> GetUserByName(string username);
        public Task AddArticle(tblCliente client, tblArticulo articulo, int quantity);
        public Task<tblCliente> AuthenticateUser(string userName, string password);
    }
}
