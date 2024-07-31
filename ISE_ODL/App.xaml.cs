using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;
using System.DirectoryServices;
using ISE_ODL.Odl;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Automation;
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
                JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string a = File.ReadAllText(MenuPrincipale_V.fileName);
            List<Odl_M> b = JsonSerializer.Deserialize<List<Odl_M>>(a, option);
            foreach (Odl_M odl_M in b)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(odl_M));
        }
    }
}
