namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe AggiungiOdl rappresenta un comando per aggiungere un'istanza di Odl_VM alla lista degli Odl.
    /// </summary>
    public class AggiungiOdl : BaseCommand
    {
        /// <summary>
        /// Rappresenta l'istanza di Odl_VM che deve essere aggiunta alla lista degli Odl.
        /// </summary>
        public Odl_VM OdlDaAggiungere;
        /// <summary>
        /// Determina se il comando può essere eseguito. Il comando è eseguibile solo se il campo Cliente dell'istanza OdlDaAggiungere non è nullo o vuoto.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando, non utilizzato in questo caso.</param>
        /// <returns>
        /// <c>true</c> se il campo Cliente di OdlDaAggiungere non è nullo o vuoto; <c>false</c> altrimenti.
        /// </returns>
        public override bool CanExecute(object parameter) => !(string.IsNullOrEmpty(OdlDaAggiungere.Cliente));
        /// <summary>
        /// Esegue il comando aggiungendo l'istanza di Odl_VM alla lista degli Odl.
        /// </summary>
        /// <param name="parameter">Parametro passato al comando, non utilizzato in questo caso.</param>
        public override void Execute(object parameter) => ObjContainer.Menuprincipale_VM.ListaOdl_VM.Commisioni.Add(OdlDaAggiungere);
    }
}
