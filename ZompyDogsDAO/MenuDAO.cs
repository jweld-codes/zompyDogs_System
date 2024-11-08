using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static ZompyDogsDAO.UsuarioDAO;

namespace ZompyDogsDAO
{
    public class MenuDAO
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public static DataTable ObtenerPlatilloParaPanel()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT Platillo, Precio FROM v_DetallesMenu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtProductos = new DataTable();
                da.Fill(dtProductos);
                return dtProductos;
            }
        }

        public static DataTable ObtenerDetallesdeMenu()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT Codigo, Platillo, Descripcion, Precio, Categoria FROM v_DetallesMenu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtMenu = new DataTable();
                da.Fill(dtMenu);
                return dtMenu;
            }
        }

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

        /* ********************* REFERENCIAS ***************************** */

        public class RegistroMenuPlatillo
        {
            public string CodigoMenu { get; set; }
            public string PlatilloName { get; set; }
            public string Descripcion { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public int CodigoCategoria { get; set; }
            public string ImagenPlatillo { get; set; }
        }

        public static void GuardarMenu(RegistroMenuPlatillo menuAdd)
        {
            string query = "INSERT INTO Menu(nombrePlatillo, Descripcion, Fk_Categoria, PrecioUnitario, imgPlatillo, codigoMenu) " +
               "VALUES (@menuPlatillo, @menuDesc, @menuCateg, @menuPrecio, @menuImg, @menuCodigo)";

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

        public static void ActualizarMenu(RegistroMenuPlatillo menuUpdate)
        {
            string query = "UPDATE Menu SET nombrePlatillo = @menuPlatillo, Descripcion = @menuDesc, " +
                           "Fk_Categoria = @menuCateg, PrecioUnitario = @menuPrecio, imgPlatillo = @menuImg " +
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
