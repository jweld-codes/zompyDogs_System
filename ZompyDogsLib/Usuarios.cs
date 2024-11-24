using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZompyDogsLib
{
    public class Usuarios
    {
        public class DetalleUsuario
        {
            public string primerNombre { get; set; }
            public string segundoNombre { get; set; }
            public string primerApellido { get; set; }
            public string segundoApellido { get; set; }
            public string codigoCedula { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public string estadoCivil { get; set; }
            public string telefono { get; set; }
            public string direccion { get; set; }
            public int codigoPuesto { get; set; }
            public string codigoUsuario { get; set; }
        }

        public class UsuarioCrear
        {
            public int IDUser { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
            public DateTime FechaRegistro { get; set; }
            public int CodigoRol { get; set; }
            public int CodigoDetalleUsuario { get; set; }
            public string Estado { get; set; }
            public string Email { get; set; }
        }

        public class ProveedorCrear
        {
            public string NombreProv { get; set; }
            public string ContactoProv { get; set; }
            public string ApellidoContactoProv { get; set; }
            public string TelefonoProv { get; set; }
            public string EmailProv { get; set; }
            public DateTime FechaRegistroProv { get; set; }
            public string EstadoProv { get; set; }
            public string CodigoProv { get; set; }
        }
        public class PuestoREF
        {
            public string Puesto { get; set; }
            public string Descripcion { get; set; }
            public Decimal Salario { get; set; }
            public TimeSpan? HoralaboralInicio { get; set; }
            public TimeSpan? HoraLaboralTermina { get; set; }
            public string DiasLaborales { get; set; }
            public string CodigoPuesto { get; set; }
            public int CodigoRol { get; set; }
            public string Estado { get; set; }
        }
    }
}
