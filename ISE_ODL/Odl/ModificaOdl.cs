namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe rappresenta un comando per modificare un ordine di lavoro (ODL) selezionato.
    /// </summary>
    public class ModificaOdl : BaseCommand
    {
        /// <summary>
        /// Verifica se il comando può essere eseguito. Il comando può essere eseguito solo se è stato selezionato un ODL.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando. Non utilizzato in questa implementazione.</param>
        /// <returns>Restituisce <c>true</c> se un ODL è selezionato, altrimenti <c>false</c>.</returns>
        public override bool CanExecute(object parameter) => ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata != null;
        /// <summary>
        /// Esegue il comando per modificare l'ODL selezionato.
        /// Imposta l'ODL selezionato in modalità di modifica e apre una finestra di dialogo per la modifica dell'ODL.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando. Non utilizzato in questa implementazione.</param>
        public override void Execute(object parameter)
        {
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata.OdlInModifica = true;
            Odl_V odl_V = new() { DataContext = ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata };
            odl_V.ShowDialog();
        }
    }
}
