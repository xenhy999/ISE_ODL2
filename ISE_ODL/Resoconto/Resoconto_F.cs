namespace ISE_ODL.Resoconto
{
    /// <summary>
    /// La classe  fornisce metodi statici per la creazione di istanze di Resoconto_VM.
    /// </summary>
    public class Resoconto_F
    {
        /// <summary>
        /// Crea una nuova istanza di Resoconto_VM con una lista vuota di giorni.
        /// </summary>
        /// <returns>
        /// Una nuova istanza di Resoconto_VM con la proprietà ListaDeiGiorni inizializzata come lista vuota.
        /// </returns>
        public static Resoconto_VM Create() => new() { ListaDeiGiorni = [] };
    }
}
