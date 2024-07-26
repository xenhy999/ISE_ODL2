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
    /// Logica di interazione per RichiestaEliminazioneOdl.xaml
    /// </summary>
    public partial class RichiestaEliminazioneOdl_V : Window
    {
        public RichiestaEliminazioneOdl_V()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Odl_VM odlDaRimuovere = ObjContainer.MenuPrincipale_VM.OdlSelezionata;
            ObjContainer.MenuPrincipale_VM.Commisioni.Remove(odlDaRimuovere);
            Close();
        }
    }
}
