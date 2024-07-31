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
        public override bool CanExecute(object parameter) => !(string.IsNullOrEmpty(OdlDaAggiornare.Cliente));
        public override void Execute(object parameter)
        {
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(OdlDaAggiornare);
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Remove(ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata);
        }
    }
}
