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

//Любен Кирев, стажант лято 2021 към софтуеристи, симулатор. email: lkirev@gmail.com, тел. 0886630617



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
            lblRole.Content = Login.getRoleName(Login.getRole());
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

            ResultForm.ListViewResult.ItemsSource = parts;

            ResultForm.Show();

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
            String input = TxtByLocation.Text;
            String room = "";
            String sub_loc = "";
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();

        }
    }
}
