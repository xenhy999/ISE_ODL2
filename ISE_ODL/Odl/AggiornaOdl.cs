using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    public /*internal*/ class AggiornaOdl : BaseCommand
    {
        public Odl_VM OdlDaAggiornare;
        public override void Execute(object parameter)
        {
            ObjContainer.MenuPrincipale_VM.Commisioni.Add(OdlDaAggiornare);
            ObjContainer.MenuPrincipale_VM.Commisioni.Remove(ObjContainer.MenuPrincipale_VM.OdlSelezionata);
        }
    }
}
