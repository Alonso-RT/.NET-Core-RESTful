using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetArticlesByStore
{
    public class GetArticlesByStoreDto
    {
        public int ArticuloID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
