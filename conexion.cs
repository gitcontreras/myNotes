using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace RepasowebApihml2.Models
{
    public static class Cls_conexion
    {
        private static IDbConnection crear_conexion(){
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString());
            con.Open();
            return con;
        }

        public static void executeNonQuery(string query) {

            using (IDbConnection conne = crear_conexion())
            {
                using (SqlCommand cmd = new SqlCommand(query,(SqlConnection)conne))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static DataTable executeQuery(string query)
        {
            DataTable table = new DataTable();

            using (IDbConnection conne = crear_conexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, (SqlConnection)conne))
                {
                    using (IDataReader rd = cmd.ExecuteReader())
                    {
                        cargarTabla(ref table,rd);
                    }
                }
            }

            return table;
        }

        private static void cargarTabla(ref DataTable table, IDataReader dr)
        {
            var schema = dr.GetSchemaTable();
            foreach (DataRowView item in schema.DefaultView)
            {
                var columname = (string)item["ColumnName"];
                var type = (Type)item["DataType"];

                table.Columns.Add(columname,type);
            }

            table.Load(dr);

        }

    }
}
