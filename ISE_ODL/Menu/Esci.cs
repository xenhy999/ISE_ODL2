using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ISE_ODL.Odl;

namespace ISE_ODL.Menu
{
    class Esci : BaseCommand
    {
        public override void Execute(object parameter)
        {
            BaseClasse.MenuPrincipale_VM.MenuPrincipale_M.Commisioni_M.Clear();
            foreach (Odl_VM odl_VM in BaseClasse.MenuPrincipale_VM.Commisioni)
            {
                BaseClasse.MenuPrincipale_VM.MenuPrincipale_M.Commisioni_M.Add((Odl_M)odl_VM);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Odl_M>), new XmlRootAttribute("Commisioni"));
            using (TextWriter writer = new StreamWriter(@"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\Commisioni.xml"))
            {
                serializer.Serialize(writer, BaseClasse.MenuPrincipale_VM.MenuPrincipale_M.Commisioni_M);
            }
        }
    }
}
