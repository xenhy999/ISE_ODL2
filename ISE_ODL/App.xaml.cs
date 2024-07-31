using System.IO;
using System.Text.Json;
using System.Windows;
using ISE_ODL.Odl;
namespace ISE_ODL
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();
            if (File.Exists(MenuPrincipale_V.fileName)) LoadFromFile();
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.Menuprincipale_VM };
            menuPrincipale_V.Show();
        }
        private void LoadFromFile()
        {
            string OdlDaDeserializzate = File.ReadAllText(MenuPrincipale_V.fileName);
            List<Odl_M> ListaOdlDeserializzate = JsonSerializer.Deserialize<List<Odl_M>>(OdlDaDeserializzate, new JsonSerializerOptions { WriteIndented = true });
            foreach (Odl_M odl_M in ListaOdlDeserializzate)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(odl_M));
        }
    }
}
