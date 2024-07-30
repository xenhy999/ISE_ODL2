using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using ISE_ODL.Intervallo;
using ISE_ODL.Intervallo.Durata;
namespace ISE_ODL.Odl
{
    public class BaseOdl_VM : BaseBinding
    {
        protected readonly BaseOdl_M _model;
        private readonly List<Durata_VM> durate;
        public BaseOdl_M Model => _model;
        public BaseOdl_VM(BaseOdl_M nessunoOdl_M)
        {
            _model = nessunoOdl_M;
        }
        public EliminaIntervallo EliminaIntervallo { get; set; }
        public ObservableCollection<Intervallo_VM> Intervalli
        {
            get
            {
                // La lista viene ricreata ogi volta a partire da quella del model
                ObservableCollection<Intervallo_VM> Out = [];
                foreach (Intervallo_M i in Model.Intervalli)
                    Out.Add(Intertevallo_F.Create(i, this));
                OrarioVisibile = Out.Count!=0;
                OnPropertyChanged(nameof(OrarioVisibile));
                return Out;
            }
        }
        public ObservableCollection<Durata_VM> Durate
        {
            get
            {
                ObservableCollection<Durata_VM> Out = [];
                foreach (DateOnly g in Intervalli.Select(i => i.Giorno).Distinct())
                {
                    TimeSpan totalSpan = new TimeSpan(Intervalli.Where(c => c.Giorno == g).Select(b => b.Durata).Sum(r => r.Ticks));
                    Out.Add(Durata_F.Create(g, totalSpan));
                }
                return Out;
            }
        }
        public string Attivita { get => _model.Attivita; set => _model.Attivita = value; }
        public bool Stato
        {
            get => _model.Stato;
            set
            {
                if ( value)
                {
                    System.Timers.Timer time = new System.Timers.Timer(2000);
                    time.Elapsed += Time_Elapsed;
                    time.Enabled

                }
                if (_model.Stato == value) return;
                _model.Stato = value;
                OrarioVisibile=true;
                OnPropertyChanged(nameof(Stato));
                OnPropertyChanged(nameof(Intervalli));
                OnPropertyChanged(nameof(Durate));
                OnPropertyChanged(nameof(OrarioVisibile));
            }
        }

        private void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            MessageBoxResult risposta = MessageBox.Show("Vuoi davvero eliminare...", "Eliminazione ODL", MessageBoxButton.OKCancel, MessageBoxImage.Question);
        }

        public bool OrarioVisibile { get; set; }
       

    }
}
