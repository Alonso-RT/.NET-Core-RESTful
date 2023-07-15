using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Queries.GetAllArticles
{
    public class ArticlesListDto
    {
        public int ArticuloID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
