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
//using Newtonsoft.Json;
//using Newtonsoft.Json;

namespace ISE_ODL
{
    
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObjContainer.Init();

            //if (File.Exists(MenuPrincipale_V.fileName))
            //foreach (string odl in File.ReadAllLines(MenuPrincipale_V.fileName))
            //    ObjContainer.MenuPrincipale_VM.Commisioni.Add(Odl_F.Create(JsonConvert.DeserializeObject<Odl_M>(odl)));


            JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string a = File.ReadAllText(MenuPrincipale_V.fileName);
            //List<Odl_M> b = JsonConvert.DeserializeObject<List<Odl_M>>(a/*,option*/);
            List<Odl_M> b = JsonSerializer.Deserialize<List<Odl_M>>(a, option);
            foreach (Odl_M odl_M in b)
                ObjContainer.MenuPrincipale_VM.Commisioni.Add(Odl_F.Create(odl_M));



            //List <Odl_M> items = JsonConvert.DeserializeObject<List<Odl_M>>(File.ReadAllText(MenuPrincipale_V.fileName), new OdlItemConverter());
            //foreach (Odl_M odl_M in items)
            //    ObjContainer.MenuPrincipale_VM.Commisioni.Add(Odl_F.Create(odl_M));

            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.MenuPrincipale_VM };
            menuPrincipale_V.Show();
        }
    }
}
