using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ZompyDogsDAO
{
    public class MenuDAO
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public string ServidorOscar = "DESKTOP-8B6OMJK";
        public string ServidorJennifer = "MACARENA";
        public string ServidorGuillermo = "GUILLERMO-ORTEG";
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
                string query = "SELECT * FROM v_DetallesMenu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtMenu = new DataTable();
                da.Fill(dtMenu);
                return dtMenu;
            }
        }


    }
}
