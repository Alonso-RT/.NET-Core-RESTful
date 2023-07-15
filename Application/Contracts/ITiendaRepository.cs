using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITiendaRepository : IGenericRepository<tblTienda>
    {
        public Task<tblTienda> GetStoreByName(string name);
        public Task AddArticle(tblTienda store, tblArticulo article);
    }
}
