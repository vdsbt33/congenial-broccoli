using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Core.Controller
{
    public class BaseController
    {
        private SqlConnection conn;
        private SqlCommand comm;

        public SqlCommand GetCommand()
        {
            if (conn == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CURR"].ConnectionString);
                comm = new SqlCommand("", conn);
            }
            return comm;
        }
        public SqlCommand GetCommand(string sql)
        {
            if (conn == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CURR"].ConnectionString);
                comm = new SqlCommand(sql, conn);
            }
            return comm;
        }

        public void CloseCommand()
        {
            if (comm != null)
            {
                conn.Close();
                comm = null;
                conn = null;
            }
        }
    }
}
