namespace ISE_ODL.Resoconto.Giorno
{
    /// <summary>
    /// La classe è una factory per la creazione di istanze di Giorno_VM.
    /// </summary>
    public class Giorno_F
    {
        /// <summary>
        /// Crea una nuova istanza dGiorno_VM utilizzando la data specificata.
        /// </summary>
        /// <param name="date">La data da utilizzare per la creazione della vista del giorno.</param>
        /// <returns>Una nuova istanza diGiorno_VM.</returns>
        public static Giorno_VM Create(DateOnly date) => new Giorno_VM(date);
    }
}
