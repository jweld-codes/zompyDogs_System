using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Peticiones
    {
        public class PeticionRegistro
        {
            public int Id { get; set; }
            public string CodigPeticion { get; set; }
            public string AccionPeticion { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaEnviada { get; set; }
            public DateTime? FechaRealizada { get; set; }
            public int CodigoUsuario { get; set; }
            public string Estado { get; set; }
            public string UserNombre { get; set; }
        }
    }
}
