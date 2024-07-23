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
            BaseClasse.MenuPrincipale_VM.Commisioni.Add(OdlDaAggiornare);
            BaseClasse.MenuPrincipale_VM.Commisioni.Remove(BaseClasse.MenuPrincipale_VM.OdlSelezionata);
        }
    }
}
