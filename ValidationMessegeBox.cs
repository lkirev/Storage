using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad
{
    class ValidationMessegeBox
    {
        public ValidationMessegeBox(String input)
        {
            MessageBox.Show("Incorrect format " + input,"Format error");
        }
    }
}
