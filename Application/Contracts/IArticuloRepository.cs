using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IArticuloRepository : IGenericRepository<tblArticulo>
    {
        public Task<tblArticulo> GetByCode(string code);
        public Task<List<tblArticulo>> GetByStoreID(int storeID);   
    }
}
