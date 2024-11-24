using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static ZompyDogsDAO.PeticionesValidaciones;
using System.Collections;
using CapaEntidad;

namespace ZompyDogsDAO
{
    public class PeticionesValidaciones
    {
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);
        
        public static void GuardarPeticion(CapaEntidad.Peticiones.PeticionRegistro peticion)
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
        public static bool ActualizarPeticion(CapaEntidad.Peticiones.PeticionRegistro peticion)
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
        public static DataTable ObtenerPeticionesCompletasAdmin()
        {
            //EN USO: Peticiones
            DataTable dtPeticionesCompletas = new DataTable();
            string query = "SELECT Codigo, Accion, Peticion, Nombre_Completo, IDUsuario, Usuario,Fecha_De_Envio,Estado FROM v_PeticionesxUsuarios ORDER BY Fecha_De_Envio DESC";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtPeticionesCompletas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtPeticionesCompletas;
        }
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
        
        
        
        
        public static DataTable FiltroPendienteCompletado(string estadoDT)
        {
            //EN USO: N/A
            DataTable dtEstados = new DataTable();
            string query = "SELECT Codigo, Accion, Peticion, Nombre_Completo, Usuario, Fecha_De_Envio, Estado FROM v_PeticionesxUsuarios WHERE estado = @estadoDT";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@estadoDT", estadoDT);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtEstados);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtEstados;
        }

    }
    
}
