using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {

            InitializeComponent();
           
            CmbBoxLoc.SelectedIndex = 0;
            //CmbBoxSubLoc.SelectedIndex = 0;
            /*foreach(String loc_name in Location.GetLocationNames())
            {
                CmbBoxLoc.Items.Add(loc_name);
            } */
            List<Location> locations = Location.GetLocationNames();
            foreach (Location l in locations)
            {
                CmbBoxLoc.Items.Add(l.Name);
            }
            //CmbBoxLoc.ItemsSource = Location.GetLocationNames();
            List<String> subloc = Location.GetSubLocation();
            //subloc.Sort();
            //List<String> subLoc1 = new List<String>();
            //List<String> subLoc2 = new List<String>();
            //List<String> sublocSorted = new List<String>();
            //String[] stringArr = new String[3];
            /*foreach (String s in subloc)
            {
                if (!s.Equals("0")) {
                Console.WriteLine("Selected: " + s);
                String[] stringArr = s.Split('-');
                Console.WriteLine("Arr length is " + stringArr.Length);
                for (int i = 0; i < stringArr.Length; i++)
                {
                    Console.WriteLine("at arr[" + i + "] is " + stringArr[i]);
                }
                //Console.WriteLine(stringArr[0]);
                //Console.WriteLine(stringArr[1]);
                //subLoc1.Add(stringArr[0]);
                }
            }*/
            foreach (String s in subloc)
            {
                Console.WriteLine("ADDING: " + s);
                CmbBoxSubLoc.Items.Add(s);

            }
            
        }
        
        /*public String AddParts()
        {
            /*Console.WriteLine(TxtId.Text);
            Console.WriteLine(TxtName.Text);
            Console.WriteLine(TxtQuantity.Text);
            Console.WriteLine(TxtDesc.Text);
            Console.WriteLine(TxtLocation.Text);
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            int quant = Convert.ToInt32(Console.ReadLine()); ;
            string desc = Console.ReadLine();
            string loc = Console.ReadLine();
            */
            /*
            Console.WriteLine("opalqnka");

            var id = TxtId.Text;
            Console.WriteLine(id.GetType());
            Console.WriteLine(id);
            Console.WriteLine(string.IsNullOrEmpty(TxtId.Text));
           // var idInt = Convert.ToInt32(id);
            //Console.WriteLine(idInt.GetType());



            int Id = int.Parse(TxtId.Text);
            String Name = TxtName.Text;
            uint Quantity;
            if(UInt32.TryParse(TxtQuantity.Text, out Quantity))
            {
                Console.WriteLine("succ2");
            }
            String Part_desc = TxtDesc.Text;
            String Part_loc = TxtLocation.Text;

            //return "INSERT INTO parts VALUES(" + Id + ", " + ", " + Name + ", " + Quantity + ", " + Part_desc + ", " + Part_loc + ")";
            return string.Format("INSERT INTO parts VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", Id, Name, Quantity, Part_desc, Part_loc);
            
        }*/
        private void BtnAddPart_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("opa");

            String loc = CmbBoxLoc.SelectedItem.ToString();
            String sub_loc = "0";
            String query = null;
            String id = TxtId.Text;
            String name = TxtName.Text;
            String quantity = TxtQuantity.Text;
            bool isThrown = false;

            Console.WriteLine("before while");
            /*while (((int.Parse(id) != 0)) && (name.Equals("")) && ((uint.Parse(quantity) <= 0)))
            {
                Console.WriteLine("In while");
                try { id = TxtId.Text; } catch { throw new MyInvalidInputException("ID"); }
                try { name = TxtName.Text; } catch { throw new MyInvalidInputException("име"); }
                try { quantity = TxtQuantity.Text; } catch { throw new MyInvalidInputException("количество"); }
            }*/

            try
            {
                if (String.IsNullOrEmpty(id) || !Regex.IsMatch(id, "^[0-9]+$"))
                {
                    throw new MyInvalidInputException("id.");
                    //isThrown = true;
                    //this.Close();
                }
                else
                {
                    if (String.IsNullOrEmpty(name))
                    {
                        throw new MyInvalidInputException("име.");
                        //isThrown = true;
                        //this.Close();
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(quantity) || !Regex.IsMatch(quantity, "^[0-9]+$") || int.Parse(quantity) < 0)
                        {
                            throw new MyInvalidInputException("количество.");
                            //isThrown = true;
                            //this.Close();
                        }
                    }
                }



                if (loc.Equals("T2"))
                {
                    try
                    {
                        sub_loc = CmbBoxSubLoc.SelectedItem.ToString();
                    }
                    catch
                    {
                        sub_loc = "0";
                    }
                    query = Part.AddPartIDT2(id, name, quantity, TxtDesc.Text, loc, sub_loc);

                }
                else
                {
                    query = Part.AddPartID(id, name, quantity, TxtDesc.Text, loc);
                }
                MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

                Database.DbConn.Open();
                //try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавена част!", "Успех!");
                }
                //catch (MySql.Data.MySqlClient.MySqlException)
                {
                    //MessageBox.Show("Вече съществува част с това ID.", "Дупликат");
                }
                Database.DbConn.Close();
            }
            catch (MyInvalidInputException)
            {
                MessageBox.Show("Грешка в добавянето на част.", "Грешка");
            }


            /*while (id.Equals("0"))
            {
                Console.WriteLine("In while2");


                try
                {
                    if (int.Parse(id) <= 0)
                    {
                        Console.WriteLine("in if id is: "+ id);
                        //id = TxtId.Text;
                    }
                    else
                    {
                        throw new MyInvalidInputException("ID");
                        this.Close();
                    }
                }
                catch { Console.WriteLine("catched"); }

            }*/

            //if (id <= 0) { throw new MyInvalidInputException("ID"); }
            //if(name.Equals("")) { throw new MyInvalidInputException("име"); }
            //if(quantity <= 0) { throw new MyInvalidInputException("количество"); }
            /*if (isThrown == false)
            {
                if (loc.Equals("T2"))
                {
                    try
                    {
                        sub_loc = CmbBoxSubLoc.SelectedItem.ToString();
                    }
                    catch
                    {
                        sub_loc = "0";
                    }
                    query = Part.AddPartIDT2(id, name, quantity, TxtDesc.Text, loc, sub_loc);

                }
                else
                {
                    query = Part.AddPartID(id, name, quantity, TxtDesc.Text, loc);
                }
                MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

                Database.DbConn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succsesfully added part!", "Succsess!");
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("An item with that ID already exists!", "Duplicate");
                }
                Database.DbConn.Close();
            }
            */
        }

        private void BtnAddLoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String loc = "";
                String subLoc = "";

                if (String.IsNullOrEmpty(TxtAddLocation.Text.ToUpper()))
                {
                    //MessageBox.Show("Error adding location");
                    throw new MyInvalidInputException("локация.");
                }
                else
                {
                    loc = TxtAddLocation.Text.ToUpper();
                    subLoc = TxtAddSubLocation.Text;
                }

                String query = Location.AddLocation(loc, subLoc);

                MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

                Database.DbConn.Open();
                cmd.ExecuteNonQuery();
                Database.DbConn.Close();

                MessageBox.Show("Успешно добавено местоположение!", "Успех");
            }
            catch(MyInvalidInputException)
            {
                MessageBox.Show("Грешка в добавянето на местоположение!", "Грешка");
                //this.Close();
            }
        }


    }
}