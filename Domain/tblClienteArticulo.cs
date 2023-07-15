using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tblClienteArticulo
    {
        [Key]
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int ArticuloID { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
