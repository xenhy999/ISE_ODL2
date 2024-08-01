using System.ComponentModel;
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
            Properties.Settings.Default.Save();
            foreach(BaseOdl_VM a in ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni)
            {
                a.Stato = false;
            }
            List<BaseOdl_M> OdlDaSerializzare = ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList();
            JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string OdlSerializzate = JsonSerializer.Serialize(OdlDaSerializzare, option);
            File.WriteAllText(fileName, OdlSerializzate);
        }
    }
}