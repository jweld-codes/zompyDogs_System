using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ZompyDogsDAO
{
   
    public class AuditoriaDAO
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public static DataTable ObtenerAuditorias()
        {
            DataTable dtAuditoria = new DataTable();
            string query = "SELECT * FROM v_AuditoriaxUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtAuditoria);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de peticiones: " + ex.Message);
                }
            }

            return dtAuditoria;
        }

    }
}
