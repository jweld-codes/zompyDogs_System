using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ZompyDogsDAO
{
    public class POSValidaciones
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        private void AddCategoria()
        {

            string qry = "SELECT * FROM Categoria";
            SqlCommand cmd = new SqlCommand(qry);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);

            if(dataTable.Rows.Count > 0)
            {

            }
        }
    }
}
