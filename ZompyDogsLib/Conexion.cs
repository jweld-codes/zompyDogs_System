using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using System.IO;

namespace ZompyDogsLib
{
    public class Conexion
    {
        public static string cadena { get; private set; }

        public static void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("La cadena de conexión no puede ser nula o vacía.");

            cadena = connectionString;
        }
    }
}
