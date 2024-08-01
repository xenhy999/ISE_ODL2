using System.ComponentModel;
using System.Windows;
using ISE_ODL.Odl;

namespace ISE_ODL.Intervallo
{
    public class EliminaIntervallo : BaseCommand
    {
        public BaseOdl_VM OdlDellIntervallo { get; set; }
        public Intervallo_M IntervalloDaEliminare { get; set; }
        public override void Execute(object parameter)
        {
            MessageBoxResult risposta = MessageBox.Show("Vuoi davvero eliminare questo intervallo di tempo", "Eliminazione intervallo di tempo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (risposta == MessageBoxResult.OK)
                Elimina(OdlDellIntervallo, IntervalloDaEliminare);
        }
        public static void Elimina(BaseOdl_VM OdlDellIntervallo, Intervallo_M IntervalloDaEliminare)
        {
            OdlDellIntervallo.Model.Intervalli.Remove(IntervalloDaEliminare);
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Intervalli));
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Durate));
        }
    }
}
