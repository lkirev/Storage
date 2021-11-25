using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sklad
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>

    public partial class Login : Window
    {

        //public static int role { get; set; }
        private static int role = 3;

        public static int getRole()
        {
            return role;
        }
        public static void setRole(int roleIn)
        {
            role = roleIn;
        }

        public Login()
        {
            //Database.InitializeDB();
            role = 3;
            InitializeComponent();
        }


        public static String getRoleName(int role)
        {
            switch (role)
            {
                
                case 1: 
                    return "Admin";
                    break;
                case 2: 
                    return "User";
                    break;
                case 3:
                    return "Guest";
                    break;
            }
            return null;
        }


        private void Login_Closing(object sender, CancelEventArgs e)
        {
            Console.WriteLine("zatvarqm");
            MainWindow main = new MainWindow();
            main.Show();
        }
        private void Login_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("zatvoverno");
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //SHA1 sha1 = new SHA1CryptoServiceProvider();

            role = 3;
           
                String username = txtName.Text;
                String password = txtPass.Password;
                Console.WriteLine(username + password);
                //byte[] password = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(txtPass.Text));
                //String PasswordHash = System.Text.Encoding.UTF8.GetString(password);
                //Console.WriteLine(PasswordHash);

                //List<User> users = new List<User>();

                //String query = String.Format("SELECT * FROM users");
                String query = string.Format("SELECT * FROM users WHERE uname = '{0}' AND upass = sha1('{1}')", username, password);

                MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

                Database.DbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

            try {
                if (!reader.HasRows) { throw new Exception(); }
                else
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("reading role from db");
                        role = (int)reader["urole"];
                    }
                    reader.Close();
                    Database.DbConn.Close();
                    Console.WriteLine("Role is: " + role);
                    this.Close();
                    //role = 3;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("User not found!", "Error!");
            }
            reader.Close();
                Database.DbConn.Close();
                Console.WriteLine("Role is: " + role);

            //if(role == 0)
            //{
                //MessageBox.Show("User not found!", "Error!");
            //}
            /*else
            {
                //MainWindow main = new MainWindow();
                //main.Show();
                Console.WriteLine("before close");
                this.Close();
                Console.WriteLine("after close");
                role = 0;
                username = null;
                password = null;
            }*/

            
        }
    }
}
