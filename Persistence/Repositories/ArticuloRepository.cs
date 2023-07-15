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
    internal class ArticuloRepository : GenericRepository<tblArticulo>, IArticuloRepository
    {
        private readonly ExamenDbContext dBContext;

        public ArticuloRepository(ExamenDbContext dBContext) : base(dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<tblArticulo> GetByCode(string code)
        {
            return await dBContext.tblArticulo.FirstOrDefaultAsync(x => string.Equals(x.Codigo, code));
        }

        public async Task<List<tblArticulo>> GetByStoreID(int storeID)
        {
            return await dBContext.tblArticuloTienda.Where(x => x.TiendaID.Equals(storeID)).
                Join(dBContext.tblArticulo, articuloTienda => articuloTienda.ArticuloID, articulos => articulos.ArticuloID, (at, a) => a).ToListAsync();
        }
    }
}
