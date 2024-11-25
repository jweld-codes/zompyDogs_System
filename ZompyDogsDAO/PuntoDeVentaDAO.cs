using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ZompyDogsLib;
using static ZompyDogsLib.PuntoDeVenta;

namespace ZompyDogsDAO
{
    public class PuntoDeVentaDAO
    {
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);

        /// <summary>
        /// Método para agregar categorías (Actualmente no implementado completamente).
        /// Este método realiza una consulta para obtener todas las categorías de la tabla `Categoria`.
        /// </summary>
        public void AddCategoria()
        {
            string qry = "SELECT * FROM Categoria"; // Consulta para obtener todas las categorías.
            SqlCommand cmd = new SqlCommand(qry); // Comando SQL.
            SqlDataAdapter da = new SqlDataAdapter(cmd); // Adaptador para llenar un DataTable.
            DataTable dataTable = new DataTable(); // Tabla donde se almacenarán los resultados.
            da.Fill(dataTable); // Llena el DataTable con los resultados de la consulta.
        }

        /// <summary>
        /// Obtiene todas las categorías desde la tabla `Categoria` de la base de datos.
        /// </summary>
        /// <returns>Un DataTable que contiene todas las categorías.</returns>
        /// <exception cref="Exception">Lanza una excepción si ocurre un error al obtener las categorías.</exception>
        public DataTable ObtenerCategorias()
        {
            string qry = "SELECT * FROM Categoria"; // Consulta para obtener todas las categorías.
            DataTable dataTable = new DataTable(); // Tabla donde se almacenarán los resultados.

            try
            {
                // Crea una conexión a la base de datos dentro de un bloque "using" para garantizar su liberación.
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    // Crea un comando SQL dentro del bloque "using".
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        // Crea un adaptador para ejecutar la consulta y llenar el DataTable.
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            conn.Open(); // Abre la conexión a la base de datos.
                            da.Fill(dataTable); // Llena el DataTable con los resultados de la consulta.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: lanza una excepción con un mensaje detallado.
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }

            return dataTable; // Devuelve el DataTable con los datos obtenidos.
        }

        /// <summary>
        /// Obtiene los platillos de una categoría específica.
        /// </summary>
        /// <param name="categoria">Categoría de los platillos a consultar.</param>
        /// <returns>Una lista de objetos anónimos con los datos de los platillos.</returns>
        public List<Platillo> ObtenerMenuPorCategoria(string categoria)
        {
            string query = "SELECT ID_Menu, Codigo, Platillo, Descripcion, Precio, Imagen FROM v_DetallesMenu WHERE Categoria = @Categoria AND Estado = 'Activo'";
            List<Platillo> platillos = new List<Platillo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Categoria", categoria);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            platillos.Add(new ZompyDogsLib.PuntoDeVenta.Platillo
                            {
                                ID_Menu = reader.GetInt32(reader.GetOrdinal("ID_Menu")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                PlatilloNombre = reader.GetString(reader.GetOrdinal("Platillo")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                                Precio = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("Precio"))), // Conversión explícita
                                Imagen = reader.IsDBNull(reader.GetOrdinal("Imagen")) ? null : reader.GetString(reader.GetOrdinal("Imagen"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el menú: " + ex.Message);
            }

            return platillos;
        }




    }
}
