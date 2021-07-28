using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Sklad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Database.InitializeDB();
            
        }

        

        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            List<Part> parts = Part.GetParts();

            foreach (Part p in parts)
            {
                p.Part_loc = Location.LocationName(int.Parse(p.Part_loc));
            }

            Result ResultForm = new Result();

            ResultForm.ListViewResult.Items.Clear();

            //foreach (Part p in parts)
            //{
            /*String[] StringArr = new String[]
            {
                p.Id.ToString(),
                p.Part_name,
                p.Quantity.ToString(),
                p.Part_desc,
                p.Part_loc
            };*/
            //ListViewItem Item = new ListViewItem(new String[] { p.Id.ToString(), p.Part_name.ToString(), p.Quantity.ToString(), p.Part_desc.ToString(), p.Part_loc.ToString() });

            //ListViewItem Item = new ListViewItem();

            //Item.Content = StringArr;

            //Item.Tag = p;

            ResultForm.ListViewResult.ItemsSource = parts;





                //resultForm.ListViewResult.Items.Add(Item);

                //Console.WriteLine(p.Id);
                //Console.WriteLine("hello");



                //resultForm.ListViewResult.co

                //resultForm.ListViewResult.Items.Add(p.id.ToString(), p.part_name, p.quantity.ToString(), p.part_desc, p.part_loc.ToString());
            //}

            ResultForm.ShowDialog();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add AddForm = new Add();
            AddForm.ShowDialog();
        }
        private void BtnId_Click(object sender, RoutedEventArgs e)
        {
            String input = TxtById.Text;
            try
            {
                if(!Regex.IsMatch(input, "^[0-9]+$"))
                {
                    throw new MyInvalidInputException("id.");
                }
                List<Part> parts = new List<Part>();

                parts = Part.PartSearchById(int.Parse(input));

                foreach (Part p in parts)
                {
                    p.Part_loc = Location.LocationName(int.Parse(p.Part_loc));
                }

                Result ResultForm = new Result();
                ResultForm.ListViewResult.Items.Clear();

                ResultForm.ListViewResult.ItemsSource = parts;

                ResultForm.ShowDialog();
            }
            catch (MyInvalidInputException) { }

            //Console.WriteLine(input);
            // String query = "SELECT * FROM parts where id = " + input + ";";
            // MySqlCommand cmd = new MySqlCommand(query, dbConn);
            

        }

        private void BtnDesc_Click(object sender, RoutedEventArgs e)
        {
            List<Part> parts = Part.PartSearchByDesc(TxtByDesc.Text);

            foreach(Part p in parts)
            {
                p.Part_loc = Location.LocationName(int.Parse(p.Part_loc));
            }

            Result ResultForm = new Result();
            ResultForm.ListViewResult.Items.Clear();

            ResultForm.ListViewResult.ItemsSource = parts;

            ResultForm.ShowDialog();
        }

        private void BtnName_Click(object sender, RoutedEventArgs e)
        {
            List<Part> parts = Part.PartSearchByName(TxtByName.Text);

            foreach (Part p in parts)
            {
                p.Part_loc = Location.LocationName(int.Parse(p.Part_loc));
            }

            Result ResultForm = new Result();
            ResultForm.ListViewResult.Items.Clear();

            ResultForm.ListViewResult.ItemsSource = parts;

            ResultForm.ShowDialog();
        }

        private void BtnLocation_Click(object sender, RoutedEventArgs e)
        {
            //try
            {
                //if(TxtByLocation.Text)
            }
            String input = TxtByLocation.Text;
            String room = "";
            String sub_loc = "";
            //string[] strings = Regex.Split(input, @"\W|_");
            string[] strings = Regex.Split(input, @"\s");

            try
            {
                room = strings[0];
            }
            catch { }
            try
            {
                sub_loc = strings[1];
            }
            catch { }
            

            Console.WriteLine(room);
            Console.WriteLine(sub_loc);

            int id = 0;
            if (strings.Length>1)
            {
                Console.WriteLine("locIdT2");
                id = Location.LocationIDT2(room, sub_loc);
            }
            else
            {
                Console.WriteLine("locIdRoom");

                id = Location.LocationID(room);
            }

            /*int id = 0;
            if (input.Contains("T2"))
            {
                for(int i = 0; i < input.Count(); i++)
                {
                    if(input.ElementAt(i).Equals(" "))
                    {
                        for(int j = 0; j <= i; j++)
                        {

                        }
                    }
                }
                id = Location.LocationIDT2(input);
            }
            else
            {
                id = Location.LocationID(input);
            }
            */
            

            List<Part> parts = Part.PartSearchByLoc(id);

            foreach (Part p in parts)
            {
                p.Part_loc = Location.LocationName(int.Parse(p.Part_loc));
            }

            Result ResultForm = new Result();
            ResultForm.ListViewResult.Items.Clear();

            ResultForm.ListViewResult.ItemsSource = parts;

            ResultForm.ShowDialog();
        }

        private void TxtById_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtById.Clear();
        }

        private void TxtById_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void TxtByName_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtByName.Clear();
        }

        private void TxtByName_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtByName.Text = "Търсене по име";
        }

        private void TxtByDesc_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtByDesc.Clear();
        }

        private void TxtByDesc_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtByDesc.Text = "Търсене по описание";
        }

        private void TxtByLocation_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtByLocation.Clear();
        }

        private void TxtByLocation_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtByLocation.Text = "Търсене по местоположение";
        }

        private void TxtById_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TxtById.Text = "Търсене по id";

        }


        /* public static void InitializeDB()
         {

             MySql.Data.MySqlClient.MySqlConnection conn;
             MySql.Data.MySqlClient.MySqlCommand cmd;

             string ConnString;

             ConnString = "server=127.0.0.1;uid=root;" + "pwd=admin;database=sklad1m";

             try
             {
                 conn = new MySql.Data.MySqlClient.MySqlConnection();
                 cmd = new MySql.Data.MySqlClient.MySqlCommand();
                 conn.ConnectionString = ConnString;
                 conn.Open();
                 cmd.Connection = conn;
             }
             catch (MySql.Data.MySqlClient.MySqlException e)
             {
                 MessageBox.Show("Error connection to DB" + e.Message);
             }

        MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection("Persist Security Info=False;server=localhost;database=sklad1m;uid=root;password=admin");

        }*/
    }


}
