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

namespace ISE_ODL
{
    
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            XmlSerializer serializer = new(typeof(List<Odl_M>), new XmlRootAttribute("Commisioni"));
            using (TextReader textReader = new StreamReader(@"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\Commisioni.xml"))
            {
                foreach (Odl_M m in (List<Odl_M>)serializer.Deserialize(textReader))
                    ObjContainer.MenuPrincipale_VM.Commisioni.Add(Odl_F.Create(m));
            }


            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = ObjContainer.MenuPrincipale_VM };
            menuPrincipale_V.Show();
        }
    }
}
