using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DbContext
    {
        private static string connectionString = "Server=DESKTOP-EDJ7DMD;Database=DEV;Encrypt=false;Trusted_Connection=True;";
        private static SqlConnection? sqlConnection;
        private static SqlCommand? sqlCommand;

        public static DataTable Execute(string sql)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(sql,sqlConnection);
      
            try
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw new Exception("CONNECTION NOT found");
            }
            finally
            {
                sqlConnection.Close();
            }
           
        }
    }
}
