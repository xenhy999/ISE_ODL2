namespace ISE_ODL.Settings
{
    /// <summary>
    /// La classe Settings_VM gestisce le impostazioni dell'applicazione.
    /// </summary>
    public class Settings_VM : BaseBinding
    {
        /// <summary>
        /// Proprietà che indica se il timer è abilitato.
        /// Il valore è memorizzato nelle impostazioni dell'applicazione.
        /// </summary>
        public bool TimerAbilitato { get => Properties.Settings.Default.TimerAttivo; set => Properties.Settings.Default["TimerAttivo"] = value; }
        /// <summary>
        /// Proprietà che indica la durata del timer.
        /// Il valore è memorizzato nelle impostazioni dell'applicazione.
        /// Quando il valore viene impostato, viene notificato il cambiamento e il timer viene ripristinato.
        /// </summary>
        public TimeSpan DurataDelTimer
        {
            get => Properties.Settings.Default.DurataDelTimer;
            set
            {
                OnPropertyChanged(nameof(DurataDelTimer));
                Properties.Settings.Default["DurataDelTimer"] = value;
                ObjContainer.OdlTimer?.ResetTimer();
            }
        }
        /// <summary>
        /// Proprietà che indica la durata minima di un ordine di lavoro (ODL).
        /// Il valore è memorizzato nelle impostazioni dell'applicazione.
        /// </summary>
        public TimeSpan DurataMinimaOdl
        {
            get => Properties.Settings.Default.DurataMinimaOdl;
            set
            {
                OnPropertyChanged(nameof(DurataMinimaOdl));
                Properties.Settings.Default["DurataMinimaOdl"] = value;
            }
        }
        /// <summary>
        /// Proprietà che indica l'intervallo di modifica per l'ODL.
        /// Il valore è memorizzato nelle impostazioni dell'applicazione.
        /// </summary>
        public TimeSpan IntervalloInModifica
        {
            get => Properties.Settings.Default.IntervalloInModifica;
            set
            {
                OnPropertyChanged(nameof(IntervalloInModifica));
                Properties.Settings.Default["IntervalloInModifica"] = value;
            }
        }
        /// <summary>
        /// URI di connessione al database MongoDB.
        /// </summary>
        public string UriDatabase
        {
            get => Properties.Settings.Default.UriDatabase;
            set
            {
                OnPropertyChanged(nameof(UriDatabase));
                Properties.Settings.Default["UriDatabase"] = value;
            }
        }
    }
}
