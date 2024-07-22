using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    internal class AggiungiOdl : BaseCommand
    {
        public Odl_VM OdlDaAggiungere;
        public override void Execute(object parameter)
        {
        BaseClasse.MenuPrincipale_VM.Commisioni.Add(OdlDaAggiungere);
        }
    }
}
