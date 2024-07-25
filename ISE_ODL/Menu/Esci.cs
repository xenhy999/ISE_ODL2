using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Serialization;
using ISE_ODL.Odl;

namespace ISE_ODL.Menu
{
    class Esci : BaseCommand
    {
        public override void Execute(object parameter)
        {
            //List<Odl_M> OdlDaSerializzare = ObjContainer.MenuPrincipale_VM.Commisioni.Where(c => c is Odl_VM).Cast<Odl_VM>().Select(cvm => cvm.Model).ToList();
            //List<string> odl = new List<string>();
            //foreach (Odl_M o in OdlDaSerializzare)
            //    odl.Add(JsonSerializer.Serialize(o));
            //File.WriteAllLines(fileName, odl);
        }
    }
}
