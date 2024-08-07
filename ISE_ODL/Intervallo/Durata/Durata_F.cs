namespace ISE_ODL.Intervallo.Durata
{
    /// <summary>
    /// La classe Durata_F fornisce un metodo per creare istanze di Durata_VM.
    /// Si tratta della factory di Durata_VM
    /// </summary>
    public class Durata_F
    {
        /// <summary>
        /// Crea una nuova istanza di Durata_VM con la data e le ore specificate.
        /// </summary>
        /// <param name="data">La data associata alla durata.</param>
        /// <param name="ore">Il periodo di tempo associato alla durata.</param>
        /// <returns>Restituisce una nuova istanza di Durata_VM con i valori specificati.</returns>
        public static Durata_VM Create(DateOnly data, TimeSpan ore) => new() { Data = data, Ore = ore };
    }
}
