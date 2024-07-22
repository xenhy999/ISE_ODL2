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

namespace ISE_ODL.Odl
{
    /// <summary>
    /// Logica di interazione per Odl_V.xaml
    /// </summary>
    public partial class Odl_V : Window
    {
        public Odl_V() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}
