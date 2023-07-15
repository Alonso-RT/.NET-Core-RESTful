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
    internal class TiendaRepository : GenericRepository<tblTienda>, ITiendaRepository
    {
        private readonly ExamenDbContext dBContext;

        public TiendaRepository(ExamenDbContext dBContext) : base(dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task AddArticle(tblTienda store, tblArticulo article)
        {
            var relation = new tblArticuloTienda { TiendaID= store.TiendaID, ArticuloID = article.ArticuloID };
            await dBContext.tblArticuloTienda.AddAsync(relation);
            await dBContext.SaveChangesAsync();
        }

        public async Task<tblTienda> GetStoreByName(string name)
        {
            return await dBContext.tblTienda.FirstOrDefaultAsync(x => string.Equals(name, x.Sucursal));
        }
    }
}
