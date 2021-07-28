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
    /// Interaction logic for QuantityDialogBox.xaml
    /// </summary>
    public partial class QuantityDialogBox : Window
    {
        public QuantityDialogBox()
        {
            InitializeComponent();
            txtAnswer.Text = "1";
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public String Answer
        {
            get
            {
                return txtAnswer.Text;
            }
        }

    }
}
