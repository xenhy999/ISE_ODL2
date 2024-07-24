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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Odl_M>), new XmlRootAttribute("Commisioni"));
            using (TextWriter writer = new StreamWriter(@"C:\Users\Huawei\Desktop\ISE_ODL\ISE_ODL\ISE_ODL\Menu\Commisioni.xml"))
            {
                serializer.Serialize(writer, ObjContainer.MenuPrincipale_VM.Commisioni.Select(c => c.Odl_M).ToList());
            }
        }
    }
}
