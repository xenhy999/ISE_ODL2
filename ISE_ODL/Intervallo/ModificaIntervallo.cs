using ISE_ODL.Odl;
namespace ISE_ODL.Intervallo
{
    public class ModificaIntervallo : BaseCommand
    {
        public BaseOdl_VM OdlDellIntervallo { get; set; }
        public Intervallo_M IntervalloDaModificare { get; set; }
        public override void Execute(object parameter)
        {
            switch ((string)parameter)
            {
                case "ai":
                    if (IntervalloDaModificare.OrarioFine - IntervalloDaModificare.OrarioInizio >= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica)
                        IntervalloDaModificare.OrarioInizio += ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "ri":
                    IntervalloDaModificare.OrarioInizio -= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "af":
                    IntervalloDaModificare.OrarioFine += ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                case "rf":
                    if (IntervalloDaModificare.OrarioFine - IntervalloDaModificare.OrarioInizio >= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica)
                        IntervalloDaModificare.OrarioFine -= ObjContainer.Menuprincipale_VM.Settings_VM.IntervalloInModifica;
                    break;
                default:
                    break;
            }
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Intervalli));
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Durate));
        }
    }
}
