using ISE_ODL.Odl;
namespace ISE_ODL.Intervallo
{
    public class ModificaIntervallo : BaseCommand
    {
        /// <summary>
        /// Proprieta relativa all'istanza di BaseOdl_VM che contiene l'intervallo da modificare.
        /// </summary>
        public BaseOdl_VM OdlDellIntervallo { get; set; }
        /// <summary>
        /// Proprietà che indica l'intervallo di tempo da modificare.
        /// </summary>
        public Intervallo_M IntervalloDaModificare { get; set; }
            /// <summary>
            /// Esegue il comando per modificare l'intervallo di tempo basato sul parametro fornito.
            /// </summary>
            /// <param name="parameter">Il parametro che indica l'operazione da eseguire, che può essere "ai" (aumenta inizio), "ri" (riduci inizio), "af" (aumenta fine) o "rf" (riduci fine).</param>
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
