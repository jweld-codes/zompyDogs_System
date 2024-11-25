using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZompyDogsLib
{
    public class PuntoDeVenta
    {
        public class Platillo
        {
            public int ID_Menu { get; set; }
            public string Codigo { get; set; }
            public string PlatilloNombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public string Imagen { get; set; }
        }

    }
}
