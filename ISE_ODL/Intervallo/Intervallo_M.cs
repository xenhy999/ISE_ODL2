namespace ISE_ODL.Intervallo
{
    /// <summary>
    /// La classe Intervallo_M rappresenta il MOdel un intervallo di tempo con dettagli su inizio, fine e validità.
    /// </summary>
    public class Intervallo_M
    {
        /// <summary>
        /// Proprietà che indica se l'orario è completo.
        /// </summary>
        public bool OrarioCompleto { get; set; }
        /// <summary>
        /// Proprietà che indica la data e l'ora di inizio dell'interavllo.
        /// </summary>
        public DateTime OrarioInizio { get; set; }
        /// <summary>
        /// Proprietà che indica la data e l'ora di fine dell'interavllo.
        /// </summary>
        public DateTime OrarioFine { get; set; }
        /// <summary>
        /// Proprietà che indica il giorno dell'interavllo.
        /// </summary>
        public DateTime Giorno { get; set; }
        /// <summary>
        /// Proprietà che indica se l'intervallo è valido o no.
        /// </summary>
        public bool IntervalloValido { get; set; }
        /// <summary>
        /// Imposta l'orario di fine dell'intervallo all'orario corrente e segna l'intervallo come completo se non è già stato impostato.
        /// </summary>
        public void EndThis()
        {
            if (OrarioFine == new DateTime())
            {
                OrarioFine = DateTime.Now;
                OrarioCompleto = true;
            }
        }
    }
}
