namespace ISE_ODL.Intervallo
{
    /// <summary>
    /// La classe Intervallo_VM rappresenta il ViewModel per l'intervallo di tempo, 
    /// e fornisce una rappresentazione dell'intervallo.
    /// </summary>
    public class Intervallo_VM : BaseBinding
    {
        /// <summary>
        /// Il Model di dati sottostante che rappresenta l'intervallo di tempo.
        /// </summary>
        private readonly Intervallo_M model;
        /// <summary>
        /// Ottiene il modello di dati sottostante a partire dall'attributo privato model.
        /// </summary>
        public Intervallo_M Model => model;
        /// <summary>
        /// Durata predefinita per la modifica dell'intervallo, impostata di default a 10 minuti.
        /// Il valore è direttamente collegato a quello del Model.
        /// </summary>
        public TimeSpan IntervalloModifica = new(0, 10, 0);
        /// <summary>
        /// Costruttore che inizializza una nuova istanza di Intervallo_VM a partire dal Model e dai comandi per l'eliminazione e la modifica.
        /// </summary>
        /// <param name="mode">Il Model di dati dell'intervallo di tempo.</param>
        /// <param name="eliminaIntervallo">Il comando per eliminare l'intervallo.</param>
        /// <param name="modificaIntervallo">Il comando per modificare l'intervallo.</param>
        public Intervallo_VM(Intervallo_M mode, EliminaIntervallo eliminaIntervallo, ModificaIntervallo modificaIntervallo)
        {
            model = mode;
            EliminaIntervallo = eliminaIntervallo;
            ModificaIntervallo = modificaIntervallo;
        }
        /// <summary>
        /// Proprietà  che contine l'istanza del comando per eliminare l'intervallo di tempo.
        /// </summary>
        public EliminaIntervallo EliminaIntervallo { get; set; }
        /// <summary>
        /// Proprietà  che contine l'istanza del comando per modificare l'intervallo di tempo.
        /// </summary>
        public ModificaIntervallo ModificaIntervallo { get; set; }
        /// <summary>
        /// Prorieta Booleana che indica che indica se l'orario di fine è stato impostato e se l'intervallo è completo.
        /// Il valore è direttamente collegato a quello del Model.
        /// </summary>
        public bool OrarioCompleto => model.OrarioCompleto;
        /// <summary>
        /// Proprietà che indica la data e l'orario di inizio dell'intervallo.
        /// Il valore è direttamente collegato a quello del Model.
        /// Notifica la modifica della proprietà quando il valore cambia.
        /// </summary>
        public DateTime OrarioInizio
        {
            get => model.OrarioInizio;
            set
            {
                model.OrarioInizio = value;
                OnPropertyChanged(nameof(OrarioInizio));
            }
        }
        /// <summary>
        /// Proprietà che indica la data e l'orario di fine dell'intervallo.
        /// Il valore è direttamente collegato a quello del Model.
        /// Notifica la modifica della proprietà quando il valore cambia.
        /// </summary>
        public DateTime OrarioFine
        {
            get => model.OrarioFine;
            set
            {
                model.OrarioFine = value;
                OnPropertyChanged(nameof(OrarioFine));
            }
        }
        /// <summary>
        /// Calcola la durata dell'intervallo come la differenza tra OrarioFine e OrarioInizio.
        /// Restituisce un intervallo vuoto se OrarioFine è minore di OrarioInizio.
        /// Il valore è direttamente collegato a quello del Model.
        /// </summary>
        public TimeSpan Durata => OrarioFine > OrarioInizio ? OrarioFine - OrarioInizio : new TimeSpan(0);
        /// <summary>
        /// Restituisce la data del giorno come oggetto DateOnly, convertito dal valore di Giorno del Model.
        /// </summary>
        public DateOnly Giorno { get => DateOnly.FromDateTime(model.Giorno); }
    }
}
