using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad
{
    class MyInvalidInputException:Exception
    {
        public MyInvalidInputException(string var)
        {
            MessageBox.Show("Въведи правилно " + var, "Грешка");
        }
        public MyInvalidInputException() { }
    }
}
