using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetClientInfo
{
    public class ClientInfoDto
    {
        public int ClienteID { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
