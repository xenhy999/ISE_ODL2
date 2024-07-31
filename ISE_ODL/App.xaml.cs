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
            if (File.Exists(MenuPrincipale_V.fileNameOdl) ) LoadFromFile();
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.Menuprincipale_VM };
            menuPrincipale_V.Show();
        }
        private void LoadFromFile()
        {
                JsonSerializerOptions? option = new JsonSerializerOptions { WriteIndented = true };
            string OdlDaDeserializzate = File.ReadAllText(MenuPrincipale_V.fileNameOdl);
            List<Odl_M> ListaOdlDeserializzate = JsonSerializer.Deserialize<List<Odl_M>>(OdlDaDeserializzate, option);
            foreach (Odl_M odl_M in ListaOdlDeserializzate)
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(Odl_F.Create(odl_M));

            string CofigDaDeserializzare= File.ReadAllText(MenuPrincipale_V.fileNameConfig);
            OdlTimer? CofigDeserializzate = JsonSerializer.Deserialize<OdlTimer>(CofigDaDeserializzare, option);
            ObjContainer.OdlTimer= CofigDeserializzate;
        }
    }
}
