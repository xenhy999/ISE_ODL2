using System.Windows;
using ISE_ODL.Odl;

namespace ISE_ODL.Intervallo
{
    /// <summary>
    /// La classe EliminaIntervallo rappresenta un comando per eliminare un intervallo di tempo associato a un Odl.
    /// Deriva dalla classe BaseCommand.
    /// </summary>
    public class EliminaIntervallo : BaseCommand
    {
        /// <summary>
        /// Proprieta relativa all'istanza di BaseOdl_VM che contiene l'intervallo da eliminare.
        /// </summary>
        public BaseOdl_VM OdlDellIntervallo { get; set; }
        /// <summary>
        /// Proprietà che indica l'intervallo di tempo da eliminare.
        /// </summary>
        public Intervallo_M IntervalloDaEliminare { get; set; }
        /// <summary>
        /// Esegue il metodo per eliminare l'intervallo di tempo specificato.
        /// </summary>
        /// <param name="parameter">Il parametro del comando (non utilizzato).</param>
        public override void Execute(object parameter)
        {
            MessageBoxResult risposta = MessageBox.Show("Vuoi davvero eliminare questo intervallo di tempo", "Eliminazione intervallo di tempo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (risposta == MessageBoxResult.OK)
                Elimina(OdlDellIntervallo, IntervalloDaEliminare);
        }
        /// <summary>
        /// Elimina l'intervallo di tempo specificato dall'Odl.
        /// </summary>
        /// <param name="OdlDellIntervallo">L'istanza di BaseOdl_VM che contiene l'intervallo da eliminare.</param>
        /// <param name="IntervalloDaEliminare">L'intervallo di tempo da eliminare.</param>
        public static void Elimina(BaseOdl_VM OdlDellIntervallo, Intervallo_M IntervalloDaEliminare)
        {
            OdlDellIntervallo.Model.Intervalli.Remove(IntervalloDaEliminare);
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Intervalli));
            OdlDellIntervallo.OnPropertyChanged(nameof(OdlDellIntervallo.Durate));
        }
    }
}
