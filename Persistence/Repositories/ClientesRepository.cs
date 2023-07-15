using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable warnings
namespace Persistence.Repositories
{
    internal class ClientesRepository : GenericRepository<tblCliente>, IClientesRepository
    {
        private readonly ExamenDbContext dBContext;

        public ClientesRepository(ExamenDbContext dBContext) : base(dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task AddArticle(tblCliente client, tblArticulo articulo, int quantity)
        {
            var relation = new tblClienteArticulo { ClienteID = client.ClienteID, ArticuloID = articulo.ArticuloID, Cantidad = quantity };
            await dBContext.tblClienteArticulo.AddAsync(relation);
            await dBContext.SaveChangesAsync();
        }

        public Task<tblCliente> AuthenticateUser(string userName, string password)
        {
            return dBContext.tblCliente.FirstOrDefaultAsync(x => x.NombreUsuario.Equals(userName) && x.Contrasena.Equals(password));
        }

        public async Task<tblCliente> GetUserByName(string username)
        {
            return await dBContext.tblCliente.FirstOrDefaultAsync(x => string.Equals(x.NombreUsuario, username));
        }
    }
}
