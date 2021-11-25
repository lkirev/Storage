using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Sklad
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {


        uint i = 0;
        uint oldQuant = 0;
        uint newQuant = 0;

        public Result()
        {
            InitializeComponent();
            ListViewResult.DataContext = Part.GetParts();
        }


        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Login.getRole() == 3){MessageBox.Show("Unauthorized!", "Error!");this.Close();}else{
                Part selected = (Part)ListViewResult.SelectedItem;
                try
                {
                    if(selected.GetType() == null){throw new NullReferenceException();}
                    QuantityDialogBox inputDialog = new QuantityDialogBox();
                    if (inputDialog.ShowDialog() == true)
                    {
                        i = uint.Parse(inputDialog.Answer);
                    }
                    oldQuant = selected.Quantity;
                    if ((oldQuant - i) > 0)
                    {
                        newQuant = oldQuant - i;
                        selected.Quantity = newQuant;
                    }
                    else
                    {
                        MessageBox.Show("Недостатъчно количество.", "Грешка");
                    }
                    String query = Part.RemovePart(selected.Id, newQuant);
                    MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);
                    Database.DbConn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Грешка в промяна на количеството.", "Грешка");
                    }
                    ListViewResult.Items.Refresh();
                    Database.DbConn.Close();
                }
                catch{MessageBox.Show("No item selected!", "Error!");}}}


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Login.getRole() == 3)
            {
                MessageBox.Show("Unauthorized!", "Error!");
                this.Close();
            }
            else
            {
                Console.WriteLine("ADDING");

                //uint i = 0;

                Part selected = (Part)ListViewResult.SelectedItem;

                try
                {
                    if (selected.GetType() == null)
                    {
                        throw new NullReferenceException();
                    }
                    Console.WriteLine("Selected " + selected.Part_name);
                    QuantityDialogBox inputDialog = new QuantityDialogBox();
                    if (inputDialog.ShowDialog() == true)
                    {
                        i = uint.Parse(inputDialog.Answer); //chisloto koeto shte dobavim
                    }
                    Console.WriteLine("za dobavqne i: " + i);

                    oldQuant = selected.Quantity;
                    //uint newQuant = 0;
                    if (i >= 0)
                    {
                        newQuant = oldQuant + i;
                        selected.Quantity = newQuant;
                    }
                    else
                    {
                        MessageBox.Show("Въведи положително число", "Грешка");
                    }
                    String query = Part.AddPartQuantity(selected.Id, newQuant);

                    MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);

                    Database.DbConn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("REFRESHING ADD");
                        ListViewResult.Items.Refresh();
                        Console.WriteLine("REFRESHED ADD");
                    }
                    catch
                    {
                        MessageBox.Show("Грешка добавяне на количество", "Грешка");
                    }

                    Database.DbConn.Close();
                }
                catch
                {
                    MessageBox.Show("No item selected!", "Error!");
                }
            }
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        public void Copy()
        {
            //DataObject dataobject = new DataObject("ListViewItems", ListViewResult.SelectedItems);
            //Clipboard.SetText(ListViewResult.SelectedItems.ToString());
            List<Part> selected = ListViewResult.SelectedItems.Cast<Part>().ToList();
            String line;
            Clipboard.SetText("");
            foreach (Part p in selected)
            {
                //line = String.Format("ID: '{0}' , Part Name: '{1}' , Qunatity: '{2}', Description: '{3}', Location: '{4}' \n", p.Id, p.Part_name, p.Quantity, p.Part_desc, Location.LocationName(int.Parse(p.Part_loc)));
                line = String.Format("ID: '{0}' , Part Name: '{1}' , Qunatity: '{2}', Description: '{3}', Location: '{4}' \n", p.Id, p.Part_name, p.Quantity, p.Part_desc, p.Part_loc);
                String temp = Clipboard.GetText();
                Clipboard.SetText(temp + line);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Login.getRole() != 1)
            {
                MessageBox.Show("Unauthorized!", "Error!");
                this.Close();
            }
            else {
                Part selected = (Part)ListViewResult.SelectedItem;
                try
                {
                    if (selected.GetType() == null)
                    {
                        throw new NullReferenceException();
                    }
                    String query = Part.DeletePart(selected.Id);
                    MySqlCommand cmd = new MySqlCommand(query, Database.DbConn);
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Сигурни ли сте, че искате да изтриете '" + selected.Part_name + "'?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        Database.DbConn.Open();
                        //try
                        {
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("deleted");
                        }
                        //catch
                        {
                            // MessageBox.Show("Error deleting", "Error");
                        }
                        Database.DbConn.Close();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No item selected!", "Error!");
                }
            }
        }
    }
}