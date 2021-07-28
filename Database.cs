using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad
{
    public static class Database
    {
        public static MySqlConnection DbConn { get; set; }

        public static void InitializeDB()
        {
            try
            {
                DbConn = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=sklad1m;uid=root;password=admin");
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                MessageBox.Show("Error connection to DB" + e.Message);
            }
        }
    }
}
