namespace ISE_ODL.Intervallo.Durata
{
    /// <summary>
    /// La classe Durata_VM rappresenta un modello di visualizzazione (ViewModel) per la durata,
    /// derivata dalla classe BaseBinding.
    /// </summary>
    public class Durata_VM : BaseBinding
    {
        /// <summary>
        /// Proprietà che indica il periodo di tempo associato alla durata.
        /// </summary>
        public TimeSpan Ore { get; set; }
        /// <summary>
        /// Proprietà che indica la data associata alla durata.
        /// </summary>
        public DateOnly Data { get; set; }
        /// <summary>
        /// Proprietà che indica se la durata è stata scaricata.
        /// </summary>
        public bool Scaricato { get; set; }
    }
}
