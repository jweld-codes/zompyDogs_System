using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static ZompyDogsDAO.PeticionesDAO;
using System.Collections;
using ZompyDogsLib;

namespace ZompyDogsDAO
{
    /// <summary>
    /// Clase que maneja las operaciones relacionadas con las peticiones en la base de datos.
    /// Realiza operaciones como insertar, actualizar, eliminar y obtener peticiones.
    /// </summary>
    public class PeticionesDAO
    {
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);

        /// <summary>
        /// Inserta una nueva petición en la base de datos.
        /// </summary>
        /// <param name="peticion">Objeto que contiene la información de la petición a guardar.</param>
        public static void GuardarPeticion(ZompyDogsLib.Peticiones.PeticionRegistro peticion)
        {
            string query = "INSERT INTO Peticiones (codigoPeticion, accionPeticion, descripcionPeticion, fechaEnviada, fechaRealizada, codigousuario, estado) VALUES (@codigopeticion, @accionpeticion, @descripcion, @fechaenviada, @fecharealizada, @codigousuario, @estado)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@codigopeticion", peticion.CodigPeticion);
                    cmd.Parameters.AddWithValue("@accionpeticion", peticion.AccionPeticion);
                    cmd.Parameters.AddWithValue("@descripcion", peticion.Descripcion);
                    cmd.Parameters.AddWithValue("@fechaenviada", peticion.FechaEnviada);
                    cmd.Parameters.AddWithValue("@fecharealizada", peticion.FechaRealizada);
                    cmd.Parameters.AddWithValue("@codigousuario", peticion.CodigoUsuario);
                    cmd.Parameters.AddWithValue("@estado", peticion.Estado);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No se insertó ningún registro en la base de datos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar la petición: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza una petición en la base de datos.
        /// </summary>
        /// <param name="peticion">Objeto que contiene la nueva información de la petición.</param>
        /// <returns>Devuelve un valor booleano indicando si la actualización fue exitosa.</returns>
        public static bool ActualizarPeticion(ZompyDogsLib.Peticiones.PeticionRegistro peticion)
        {
            string query = "UPDATE Peticiones SET accionPeticion = @nuevaAccionPeticion, " +
                           "descripcionPeticion = @nuevaDescripcionPeticion, fechaRealizada = @nuevaFechaRealizada, " +
                           "estado = @nuevoEstado WHERE codigoPeticion = @codigoPeticion";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nuevaAccionPeticion", peticion.AccionPeticion);
                cmd.Parameters.AddWithValue("@nuevaDescripcionPeticion", peticion.Descripcion);
                cmd.Parameters.AddWithValue("@nuevaFechaRealizada", peticion.FechaRealizada);
                cmd.Parameters.AddWithValue("@nuevoEstado", peticion.Estado);
                cmd.Parameters.AddWithValue("@codigoPeticion", peticion.CodigPeticion);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar la petición: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina una petición de la base de datos.
        /// </summary>
        /// <param name="codigoPeticion">Código de la petición a eliminar.</param>
        /// <returns>Devuelve un valor booleano indicando si la eliminación fue exitosa.</returns>
        public static bool EliminarPeticion(string codigoPeticion)
        {
            string query = "DELETE FROM Peticiones WHERE codigoPeticion = @codigoPeticion";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoPeticion", codigoPeticion);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la petición: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene las 10 peticiones más recientes con estado 'Pendiente' para mostrar en el PanelAdmin.
        /// </summary>
        /// <returns>Devuelve un DataTable con las 10 primeras peticiones pendientes ordenadas por la fecha de envío en orden descendente.</returns>
        /// <remarks>Este método está diseñado para ser utilizado en el PanelAdmin, y obtiene una lista de las peticiones pendientes más recientes.</remarks>
        public static DataTable ObtenerPeticionesParaPanel()
        {
            // USO EN: PanelAdmin
            DataTable dtPeticiones = new DataTable();
            string query = "SELECT TOP 10 Peticion, Usuario, Fecha_De_Envio FROM v_PeticionesxUsuarios WHERE estado = 'Pendiente' ORDER BY Fecha_De_Envio DESC";


            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticiones);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtPeticiones;
        }

        /// <summary>
        /// Obtiene todas las peticiones con estado "Pendiente" de la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con las peticiones pendientes.</returns>
        public static DataTable ObtenerPeticionesPendientes()
        {
            // USO EN: Peticiones
            DataTable dtPeticiones = new DataTable();
            string query = "SELECT Codigo, Accion, Peticion, Usuario, Correo, Fecha_De_Envio, Estado FROM v_PeticionesxUsuarios WHERE Estado = 'Pendiente' ORDER BY Fecha_De_Envio DESC";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticiones);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtPeticiones;
        }

        /// <summary>
        /// Obtiene todas las peticiones con estado "Completado" de la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con las peticiones completadas.</returns>
        public static DataTable ObtenerPeticionesCompletadas()
        {
            // USO EN: Peticiones
            DataTable dtPeticiones = new DataTable();
            string query = "SELECT Codigo, Accion, Peticion, Usuario, Fecha_De_Envio, Estado FROM v_PeticionesxUsuarios WHERE Estado = 'Completado' ORDER BY Fecha_De_Envio DESC";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticiones);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtPeticiones;
        }

        /// <summary>
        /// Obtiene las peticiones completadas de un empleado específico.
        /// </summary>
        /// <param name="idUsuario">ID del usuario para filtrar las peticiones.</param>
        public static DataTable ObtenerPeticionesCompletasAjustes(int idUsuario)
        {
            //EN USO: AjustesCuenta
            DataTable dtPeticionesCompletasEmp = new DataTable();
            string query = "SELECT Codigo, Accion, Peticion, Fecha_De_Envio, Estado FROM v_PeticionesxUsuarios WHERE IDUsuario = @idUsuario ORDER BY Fecha_De_Envio DESC";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticionesCompletasEmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }
            return dtPeticionesCompletasEmp;
        }

        /// <summary>
        /// Obtiene los detalles de una petición específica para su edición.
        /// </summary>
        /// <param name="codigoPeticion">Código de la petición a obtener.</param>
        /// <returns>Devuelve un DataTable con la información de la petición.</returns>
        public static DataTable ObtenerPeticionesUsuarioParaEditar(string codigoPeticion)
        {
            //EN USO: AjustesCuenta, Peticiones
            DataTable dtPeticionesCompletasEmp = new DataTable();
            string query = "SELECT * FROM v_PeticionesxUsuarios WHERE Codigo = @codiPeticion ORDER BY Fecha_De_Envio DESC";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codiPeticion", codigoPeticion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticionesCompletasEmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }
            return dtPeticionesCompletasEmp;
        }
        
        
        /* ************ BUSCADORES ****************** */
        public static DataTable BuscarPeticionesPorUsuario(string valorBusqueda)
        {
            //EN USO: Peticiones
            string query = "SELECT Codigo, Accion, Peticion, Nombre_Completo, IDUsuario, Usuario,Fecha_De_Envio,Estado FROM v_PeticionesxUsuarios WHERE Usuario LIKE @valorBusqueda OR Nombre_Completo LIKE @valorBusqueda OR Codigo LIKE @valorBusqueda";

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valorBusqueda", "%" + valorBusqueda + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }
        public static DataTable BuscarPeticionesPorIDUsuario(int idUsuario)
        {
            //EN USO: Peticiones
            DataTable dtPeticionesCompletasEmp = new DataTable();
            string query = "SELECT Usuario FROM v_PeticionesxUsuarios WHERE IDUsuario = @idUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticionesCompletasEmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }
            return dtPeticionesCompletasEmp;
        }
        
    }
    
}
