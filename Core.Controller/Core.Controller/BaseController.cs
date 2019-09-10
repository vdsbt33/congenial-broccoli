using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Core.Controller
{
    public class BaseController
    {
        private MySqlConnection conn;
        private MySqlCommand comm;

        public MySqlCommand GetCommand()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CURR"].ConnectionString);
                comm = new MySqlCommand("", conn);
            }
            return comm;
        }
        public MySqlCommand GetCommand(string sql)
        {
            if (conn == null)
            {
                conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CURR"].ConnectionString);
                comm = new MySqlCommand(sql, conn);
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
