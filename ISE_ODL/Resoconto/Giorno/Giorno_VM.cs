using ISE_ODL.Odl;
namespace ISE_ODL.Resoconto.Giorno
{
    /// <summary>
    /// La classe rappresenta una ViewModel per una data specifica.
    /// </summary>
    public class Giorno_VM : BaseBinding
    {
        private DateOnly data;
        /// <summary>
        /// Inizializza una nuova istanza di Giorno_VM con la data specificata.
        /// </summary>
        /// <param name="data">La data associata a questa vista del giorno.</param>
        public Giorno_VM(DateOnly data) => Data = data;
        /// <summary>
        /// Proprietà che indica la data per questa vista del giorno.
        /// </summary>
        /// <value>
        /// La data associata a questa vista del giorno.
        /// </value>
        public DateOnly Data
        {
            get => data;
            set
            {
                data = value;
                if (data == DateOnly.FromDateTime(DateTime.Now)) DataOdierna = true;
                else DataOdierna = false;
                OnPropertyChanged(nameof(DataOdierna));
            }
        }
        /// <summary>
        /// Proprietà che indica un dizionario che associa un'istanza di Odl_VM a un TimeSpan che rappresenta il tempo lavorato.
        /// </summary>
        /// <value>
        /// Un dizionario in cui la chiave è un'istanza di Odl_VM e il valore è un TimeSpan che rappresenta il tempo lavorato per quel ODL.
        /// </value>
        public Dictionary<Odl_VM, TimeSpan> OdlLavorati { get; set; } = [];
        /// <summary>
        /// Proprietà che indica se la data è odierna.
        /// </summary>
        /// <value>
        /// <c>true</c> se la data è la data odierna; in caso contrario, <c>false</c>.
        /// </value>
        public bool DataOdierna { get; set; }
    }
}
