using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace zompyDogs
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Pasa la conexión a la librería
            ZompyDogsLib.Conexion.SetConnectionString(connectionString);

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}