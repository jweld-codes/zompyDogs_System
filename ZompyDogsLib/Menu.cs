using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZompyDogsLib
{
    public class Menu
    {
        public class RegistroMenuPlatillo
        {
            public string CodigoMenu { get; set; }
            public string PlatilloName { get; set; }
            public string Descripcion { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public int CodigoCategoria { get; set; }
            public string ImagenPlatillo { get; set; }
            public string Estado { get; set; }
        }
    }
}
