namespace ISE_ODL.Odl
{
    /// <summary>
    /// La classe BaseOdl_F fornisce metodi statici per creare e inizializzare istanze di BaseOdl_VM. 
    /// Si tratta della factory per gli elementi BaseOdl_VM
    /// </summary>
    public class BaseOdl_F
    {
        /// <summary>
        /// Crea una nuova istanza di BaseOdl_VM con un'istanza di BaseOdl_M predefinita.
        /// Imposta i valori predefiniti per le proprietà Attivita e Stato.
        /// Si tratta dell Odl posta in cima alla lista
        /// </summary>
        /// <returns>
        /// Una nuova istanza di BaseOdl_VM con Attivita impostata su "Nessun ordine di lavoro" e Stato impostato su true.
        /// </returns>
        public static BaseOdl_VM Create() => new(new BaseOdl_M()) { Attivita = "Nessun ordine di lavoro", Stato = true };
    }
}
