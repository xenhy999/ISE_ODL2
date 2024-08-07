using System.Windows;
namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe EliminaOdl rappresenta un comando per eliminare un ordine di lavoro (Odl).
    /// </summary>
    public class EliminaOdl : BaseCommand
    {
        private const string MessageBoxText = "Vuoi davvero eliminare questa ODL";
        private const string Caption = "Eliminazione ODL";
        /// <summary>
        /// Verifica se il comando può essere eseguito. Il comando può essere eseguito solo se è stato selezionato un ODL.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando. Non utilizzato in questa implementazione.</param>
        /// <returns>Restituisce <c>true</c> se un ODL è selezionato, altrimenti <c>false</c>.</returns>
        public override bool CanExecute(object parameter) => ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata != null;
        /// <summary>
        /// Esegue il comando per eliminare l'ODL selezionato.
        /// Mostra una finestra di conferma e, se l'utente conferma l'azione, rimuove l'ODL selezionato dalla lista.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando. Non utilizzato in questa implementazione.</param>
        public override void Execute(object parameter)
        {
            if (MessageBox.Show(MessageBoxText, Caption, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Odl_VM odlDaRimuovere = ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata;
                ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Remove(odlDaRimuovere);
            }
        }
    }
}
