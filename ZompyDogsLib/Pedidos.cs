using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZompyDogsLib
{
    public class Pedidos
    {
        public class RegistroPedidos
        {
            public string CodigoPedido { get; set; }
            public int CodigoEmpleado { get; set; }
            public string EmpleadoNombre { get; set; }
            public DateTime FechaDelPedido { get; set; }
            public string Estado { get; set; }
        }

        public class DetalleDePedido
        {
            public int id_Menu { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio_Unitario { get; set; }
            public int id_Pedido { get; set; }
            public string PlatilloNombre { get; set; }
            public string Descripcion { get; set; }
            public int Categoria { get; set; }
            public string ImagenPlatillo { get; set; }
            public decimal SubTotal { get; set; }
        }

    }
}
