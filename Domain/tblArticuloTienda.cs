using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tblArticuloTienda
    {
        public int ArticuloID { get; set; }
        public int TiendaID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
