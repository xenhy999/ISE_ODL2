using System.IO;
using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    public partial class MenuPrincipale_V : Window
    {
        public static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Commisioni.json";
        public MenuPrincipale_V() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Closed(object sender, EventArgs e)
        {
            List<Odl_M> OdlDaSerializzare = ObjContainer.MenuPrincipale_VM.Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>().Select(cvm => cvm.Model).ToList();
            List<string> odl = new List<string>();
            foreach (Odl_M o in OdlDaSerializzare) odl.Add(JsonSerializer.Serialize(o));
            File.WriteAllLines(fileName, odl);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RichiestaEliminazioneOdl_V richiestaEliminazioneOdl_V = new RichiestaEliminazioneOdl_V();
            richiestaEliminazioneOdl_V.Show();
        }
    }
}