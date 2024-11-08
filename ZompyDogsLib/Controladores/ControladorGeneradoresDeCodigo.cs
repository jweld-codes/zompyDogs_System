using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZompyDogsLib.Controladores
{
    public class ControladorGeneradoresDeCodigo
    {

        public string GeneradordeCodigoUsuario()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMddHHmmss");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoUsuario = $"USR-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoUsuario;
        }

        public string GeneradordeCodigoProveedor()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMddHHmmss");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoProveedor = $"PRV-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoProveedor;
        }

        public string GeneradordeCodigoPeticion()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMdd");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoPeticion = $"PTC-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoPeticion;
        }
        public string GeneradordeCodigoPuesto()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMdd");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoPuesto = $"PST-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoPuesto;
        }

        public string GeneradordeCodigoPedidos()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMdd");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoPedidos = $"PED-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoPedidos;
        }

        public string GeneradordeCodigoMenu()
        {
            string fechaRegistro = DateTime.Now.ToString("yyyyMMdd");
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoMenu = $"MNU-{fechaRegistro}-{numeroAleatorio}";

            return codigoGeneradoMenu;
        }

    }
}
