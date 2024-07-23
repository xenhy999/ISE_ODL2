using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;
using System.DirectoryServices;
using ISE_ODL.Odl;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace ISE_ODL
{
    
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Odl_M>), new XmlRootAttribute("Commisioni"));
            using (TextReader textReader = new StreamReader(@"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\Commisioni.xml"))
            {
                BaseClasse.MenuPrincipale_VM.MenuPrincipale_M.Commisioni_M = (ObservableCollection<Odl_M>)serializer.Deserialize(textReader);
            }
            foreach (Odl_M odl_M in BaseClasse.MenuPrincipale_VM.MenuPrincipale_M.Commisioni_M)
            {
                BaseClasse.MenuPrincipale_VM.Commisioni.Add((Odl_VM)odl_M);
            }
            MenuPrincipale_V menuPrincipale_V = new MenuPrincipale_V { DataContext = BaseClasse.MenuPrincipale_VM };
            menuPrincipale_V.Show();
        }
    }
}
