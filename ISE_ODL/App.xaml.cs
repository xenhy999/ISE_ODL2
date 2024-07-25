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
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ISE_ODL
{
    
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();

            if (File.Exists(MenuPrincipale_V.fileName))
                foreach (string odl in File.ReadAllLines(MenuPrincipale_V.fileName))
                    ObjContainer.MenuPrincipale_VM.Commisioni.Add(Odl_F.Create(JsonConvert.DeserializeObject<Odl_M>(odl)));
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.MenuPrincipale_VM };
            menuPrincipale_V.Show();
        }
    }
}
