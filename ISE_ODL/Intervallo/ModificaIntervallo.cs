using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISE_ODL.Odl;

namespace ISE_ODL.Intervallo
{
    public class ModificaIntervallo : BaseCommand
    {
        public BaseOdl_VM OdlDellIntervallo { get; set; }
        public Intervallo_M IntervalloDaModificare
        {
            get; set;
        }
        public override void Execute(object parameter)
        {
            string caso = (string)parameter;
            switch (caso)
            {
                case "ai":
                    IntervalloDaModificare.OrarioInizio += ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "ri":
                    IntervalloDaModificare.OrarioInizio -= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "af":
                    IntervalloDaModificare.OrarioFine += ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "rf":
                    IntervalloDaModificare.OrarioFine -= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
            }
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Intervalli));
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Durate));

        }
    }
}
