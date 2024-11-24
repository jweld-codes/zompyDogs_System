using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace ZompyDogsDAO
{
    public class PuntoDeVentaDAO
    {
        private static readonly string con_string = Conexion.cadena;
        private static SqlConnection conn = new SqlConnection(con_string);
        public void AddCategoria()
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

        public DataTable ObtenerCategorias()
        {
            string qry = "SELECT * FROM Categoria";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            conn.Open();
                            da.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }

            return dataTable;
        }

    }
}
