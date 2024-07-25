using System.IO;
using System.Windows;
using ISE_ODL.Odl;
using System.Text.Json;
namespace ISE_ODL
{
    public partial class MenuPrincipale_V : Window
    {
        private const string fileName = @"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\Commisioni.json";

        public MenuPrincipale_V() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        private void Window_Closed(object sender, EventArgs e)
        {
            List<Odl_M> OdlDaSerializzare = ObjContainer.MenuPrincipale_VM.Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>().Select(cvm => cvm.Model).ToList();
            List<string> odl = new List<string>();
            foreach (Odl_M o in OdlDaSerializzare) odl.Add(JsonSerializer.Serialize(o));
            File.WriteAllLines(fileName, odl);
        }
    }
}