using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ISE_ODL.Odl
{
    public/*internal*/ class AggiungiOdl : BaseCommand
    {
        public Odl_VM OdlDaAggiungere;
        public override bool CanExecute(object parameter) => !(string.IsNullOrEmpty(OdlDaAggiungere.Cliente));
        public override void Execute(object parameter) => ObjContainer.MenuPrincipale_VM.Commisioni.Add(OdlDaAggiungere);
    }
}
