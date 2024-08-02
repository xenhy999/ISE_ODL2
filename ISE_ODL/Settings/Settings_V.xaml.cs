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

namespace ISE_ODL.Settings
{
    /// <summary>
    /// Logica di interazione per Settings_V.xaml
    /// </summary>
    public partial class Settings_V : UserControl
    {
        public Settings_V()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.DurataMinimaOdl=new TimeSpan(0,5,0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.DurataDelTimer = new TimeSpan(1, 0, 0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica = new TimeSpan(0, 10, 0);
        }
    }
}
