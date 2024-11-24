using System.Data;
using System.Data.SqlClient;
using ZompyDogsLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;



namespace ZompyDogsDAO
{
    public class LoginValidacion
    {
        // Usamos la cadena de conexión de la clase Conexion
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);

        // Metodo para validar el usuario y obtener sus datos
        public static (
            bool isValid,
            bool isAdmin,
            string nombreUser,
            string apeUser,
            string username,
            int idEmpleado,
            int idRol
) IsValidUser(string user, string clave)
        {
            bool isValid = false;
            bool isAdmin = false;
            string nombreUser = string.Empty;
            string apeUser = string.Empty;
            string username = string.Empty;
            int idEmpleado = 0;
            int idRol =0;

            try
            {
                // Confirmamos los valores recibidos
                Console.WriteLine("Intentando validar el usuario: " + user + " con la clave proporcionada.");

                conn.Open();
                Console.WriteLine("Conexión a la base de datos establecida.");

                // Consulta para validar el usuario y la clave
                string query = @"
                SELECT Nombre_Usuario, Apellido_Usuario, Usuario, IDUsuario, RolId 
                FROM v_DetallesUsuarios
                WHERE Usuario = @user AND Clave = @password
            ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@password", clave);

                // Confirmamos los parámetros establecidos en la consulta
                System.Diagnostics.Debug.WriteLine("Parámetros asignados: usuario = " + user + ", clave = " + clave);

                SqlDataReader reader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine("Consulta ejecutada.");

                if (reader.HasRows)
                {
                    isValid = true;
                    System.Diagnostics.Debug.WriteLine("Usuario encontrado en la base de datos.");

                    while (reader.Read())
                    {

                        nombreUser = reader["Nombre_Usuario"].ToString();
                        apeUser = reader["Apellido_Usuario"].ToString();
                        username = reader["Usuario"].ToString();
                        idEmpleado = reader.GetInt32(reader.GetOrdinal("IDUsuario"));
                        idRol = reader.GetInt32(reader.GetOrdinal("RolId"));

                        System.Diagnostics.Debug.WriteLine("Datos obtenidos: Nombre = " + nombreUser + ", Apellido = " + apeUser + ", Usuario = " + username);

                        if (reader["RolId"] != DBNull.Value && Convert.ToInt32(reader["RolId"]) == 1)
                        {
                            isAdmin = true;
                            System.Diagnostics.Debug.WriteLine("El usuario tiene permisos de administrador.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña incorrectos. No se encontraron filas.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
            }

            return (isValid, isAdmin, nombreUser, apeUser, username, idEmpleado, idRol);
        }
    }
}
