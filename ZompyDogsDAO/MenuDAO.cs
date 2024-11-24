using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static ZompyDogsDAO.UsuarioDAO;
using ZompyDogsLib;

namespace ZompyDogsDAO
{
    /// <summary>
    /// Clase que maneja las operaciones de acceso a datos relacionadas con el menú en la base de datos.
    /// </summary>
    public class MenuDAO
    {
        // Cadena de conexión a la base de datos.
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);

        // <summary>
        /// Obtiene los detalles del menú, incluyendo el código, nombre del platillo, precio, categoría y estado.
        /// </summary>
        /// <returns>Un DataTable con los detalles del menú.</returns>
        public static DataTable ObtenerDetallesdeMenu()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT Codigo, Platillo, Precio, Categoria, Estado FROM v_DetallesMenu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtMenu = new DataTable();
                da.Fill(dtMenu);
                return dtMenu;
            }
        }

        /// <summary>
        /// Obtiene las categorías disponibles para un ComboBox.
        /// </summary>
        /// <returns>Un DataTable con las categorías.</returns>
        public static DataTable ObtenerCategoriaParaComboBox()
        {
            DataTable dtCategoria = new DataTable();
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                conn.Open();
                string query = "SELECT IdCategoria, Categoria FROM Categoria;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtCategoria);
                }
            }
            return dtCategoria;
        }

        /// <summary>
        /// Guarda un nuevo platillo en el menú.
        /// </summary>
        /// <param name="menuAdd">Objeto de tipo RegistroMenuPlatillo con los detalles del platillo a agregar.</param>
        public static void GuardarMenu(ZompyDogsLib.Menu.RegistroMenuPlatillo menuAdd)
        {
            string query = "INSERT INTO Menu(nombrePlatillo, Descripcion, Fk_Categoria, PrecioUnitario, imgPlatillo, codigoMenu, estado) " +
               "VALUES (@menuPlatillo, @menuDesc, @menuCateg, @menuPrecio, @menuImg, @menuCodigo, @menuEstado)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menuPlatillo", menuAdd.PlatilloName);
                    cmd.Parameters.AddWithValue("@menuDesc", menuAdd.Descripcion);
                    cmd.Parameters.AddWithValue("@menuCateg", menuAdd.CodigoCategoria);
                    cmd.Parameters.AddWithValue("@menuPrecio", menuAdd.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@menuImg", menuAdd.ImagenPlatillo);
                    cmd.Parameters.AddWithValue("@menuCodigo", menuAdd.CodigoMenu);
                    cmd.Parameters.AddWithValue("@menuEstado", menuAdd.Estado);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar el menu: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene los detalles de un platillo específico a partir del código del menú.
        /// </summary>
        /// <param name="codigoMenu">Código del platillo a editar.</param>
        /// <returns>Un DataTable con los detalles del platillo.</returns>
        public static DataTable ObtenerDetalllesMenuParaEditar(string codigoMenu)
        {
            DataTable dtpPuestos = new DataTable();
            string query = "SELECT * FROM v_DetallesMenu WHERE Codigo = @codiMenu";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codiMenu", codigoMenu);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpPuestos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de puestos: " + ex.Message);
                }
            }

            return dtpPuestos;
        }

        /// <summary>
        /// Actualiza un platillo en el menú con nuevos detalles.
        /// </summary>
        /// <param name="menuUpdate">Objeto de tipo RegistroMenuPlatillo con los nuevos detalles del platillo.</param>
        public static void ActualizarMenu(ZompyDogsLib.Menu.RegistroMenuPlatillo menuUpdate)
        {
            string query = "UPDATE Menu SET nombrePlatillo = @menuPlatillo, Descripcion = @menuDesc, " +
                           "Fk_Categoria = @menuCateg, PrecioUnitario = @menuPrecio, imgPlatillo = @menuImg, estado = @menuEstado " +
                           "WHERE codigoMenu = @menuCodigo";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menuPlatillo", menuUpdate.PlatilloName);
                    cmd.Parameters.AddWithValue("@menuDesc", menuUpdate.Descripcion);
                    cmd.Parameters.AddWithValue("@menuCateg", menuUpdate.CodigoCategoria);
                    cmd.Parameters.AddWithValue("@menuPrecio", menuUpdate.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@menuImg", menuUpdate.ImagenPlatillo);
                    cmd.Parameters.AddWithValue("@menuCodigo", menuUpdate.CodigoMenu);
                    cmd.Parameters.AddWithValue("@menuEstado", menuUpdate.Estado);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Menu actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el platillo con el código especificado.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error de SQL al actualizar el menu: " + ex.Message);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error general al actualizar el menu: " + ex.Message);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Elimina un platillo del menú.
        /// </summary>
        /// <param name="codigoMenu">Código del platillo a eliminar.</param>
        /// <returns>True si el platillo fue eliminado exitosamente, False en caso contrario.</returns>
        public static bool EliminarPlatillo(string codigoMenu)
        {
            string query = "DELETE FROM Menu WHERE codigoMenu = @codiMenu";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codiMenu", codigoMenu);

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
        /// Realiza una búsqueda de platillos en el menú por código, nombre o categoría.
        /// </summary>
        /// <param name="valorBusqueda">Valor a buscar.</param>
        /// <returns>Un DataTable con los platillos que coinciden con el valor de búsqueda.</returns>
        public static DataTable BuscadorDePlatillos(string valorBusqueda)
        {
            string query = "SELECT  Codigo, Platillo, Descripcion, Precio, Categoria FROM v_DetallesMenu WHERE Codigo LIKE @valorBusqueda OR Platillo LIKE @valorBusqueda OR Categoria LIKE @valorBusqueda";

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


    }
}
