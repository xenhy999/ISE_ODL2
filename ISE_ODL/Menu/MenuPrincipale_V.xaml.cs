using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    public partial class MenuPrincipale_V : Window
    {
        // public static readonly string fileName = @$"{AppDomain.CurrentDomain.BaseDirectory}\Commisioni.json";
        public static readonly string fileName = @$"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\commissioni.json";
        public MenuPrincipale_V() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Closed(object sender, EventArgs e)
        {
            List<BaseOdl_M> OdlDaSerializzare = ObjContainer.MenuPrincipale_VM.Commisioni.Where(c => c is Odl_VM).Select(cvm => cvm.Model).ToList();

            JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string b = JsonSerializer.Serialize(OdlDaSerializzare, option);
            File.WriteAllText(fileName, b);
        }
    }
}