using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using System.IO;

namespace CapaEntidad
{
    public class Conexion
    {
        public static string cadena;

        static Conexion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            cadena = configuration.GetConnectionString("cadena_conexion");
        }
    }
}
