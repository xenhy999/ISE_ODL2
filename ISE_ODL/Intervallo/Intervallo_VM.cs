namespace ISE_ODL.Intervallo
{
    public class Intervallo_VM : BaseBinding
    {
        private readonly Intervallo_M model;
        public Intervallo_M Model => model;
        public TimeSpan IntervalloModifica = new(0, 10, 0);
        public Intervallo_VM(Intervallo_M mode, EliminaIntervallo eliminaIntervallo, ModificaIntervallo modificaIntervallo)
        {
            model = mode;
            EliminaIntervallo = eliminaIntervallo;
            ModificaIntervallo = modificaIntervallo;
        }
        public EliminaIntervallo EliminaIntervallo { get; set; }
        public ModificaIntervallo ModificaIntervallo { get; set; }
        public bool OrarioCompleto => model.OrarioCompleto;
        public DateTime OrarioInizio
        {
            get => model.OrarioInizio;
            set
            {
                model.OrarioInizio = value;
                OnPropertyChanged(nameof(OrarioInizio));
            }
        }
        public DateTime OrarioFine
        {
            get => model.OrarioFine;
            set
            {
                model.OrarioFine = value;
                OnPropertyChanged(nameof(OrarioFine));
            }
        }
        public TimeSpan Durata => OrarioFine > OrarioInizio ? OrarioFine - OrarioInizio : new TimeSpan(0);
        public DateOnly Giorno { get => DateOnly.FromDateTime(model.Giorno); }
    }
}
