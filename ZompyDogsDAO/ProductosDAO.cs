using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ZompyDogsDAO
{
    public class ProductosDAO
    {
        private static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";

        public static DataTable ObtenerProductosRecientes()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT * FROM v_ProductosRecientesAgregados ORDER BY Fecha_De_Compra DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtProductos = new DataTable();
                da.Fill(dtProductos);
                return dtProductos;
            }
        }

        public static DataTable ObtenerDetalllesProductos()
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT * FROM v_ProductosRecientesAgregados";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }





    }
}
