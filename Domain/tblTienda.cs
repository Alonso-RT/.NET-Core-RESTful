using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tblTienda
    {
        [Key]
        public int TiendaID { get; set; }
        public string Sucursal { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
