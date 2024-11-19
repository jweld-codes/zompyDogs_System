using Microsoft.Extensions.Configuration;

namespace zompyDogs
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            
            

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}