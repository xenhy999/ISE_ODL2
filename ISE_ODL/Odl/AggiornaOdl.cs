namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe AggiornaOdl rappresenta un comando per aggiornare un'istanza di Odl_VM nella lista degli Odl.
    /// </summary>
    public class AggiornaOdl : BaseCommand

    {
        /// <summary>
        /// Rappresenta l'istanza di Odl_VM che deve essere aggiornata.
        /// </summary>
        public Odl_VM OdlDaAggiornare;
        /// <summary>
        /// Determina se il comando può essere eseguito. Il comando è eseguibile solo se il campo Cliente dell'istanza OdlDaAggiornare non è nullo o vuoto.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando, non utilizzato in questo caso.</param>
        /// <returns>
        /// <c>true</c> se il campo Cliente di OdlDaAggiornare non è nullo o vuoto; <c>false</c> altrimenti.
        /// </returns>
        public override bool CanExecute(object parameter) => !(string.IsNullOrEmpty(OdlDaAggiornare.Cliente));
        /// <summary>
        /// Esegue il comando aggiornando l'istanza di Odl_VM nella lista degli Odl.
        /// Aggiunge l'istanza OdlDaAggiornare alla lista Commisioni e rimuove l'istanza vecchia.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando, non utilizzato in questo caso.</param>
        public override void Execute(object parameter)
        {
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(OdlDaAggiornare);
            ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Remove(ObjContainer.Menuprincipale_VM.ListaOdl_VM.OdlSelezionata);
        }
    }
}
